using System.Diagnostics;

class Program
{
    /// <summary>
    /// Goes through the files and extracts the lists and passes them back as a list of doubles
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static List<double[]> GetListFromFile (string filePath) 
    {
        var listOfDoubleArrays = new List<double[]>();
        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var stringNumbers = line.Split(',');
                var doubleArray = new double[stringNumbers.Length];
                for (int i = 0; i < stringNumbers.Length; i++)
                {
                    doubleArray[i] = double.Parse(stringNumbers[i].Trim());
                }
                listOfDoubleArrays.Add(doubleArray);
            }

            //For testing if the files are being read properly
            // foreach (var index in listOfDoubleArrays) 
            // {
            //     string kin = "";
            //     foreach (var lindex in index)
            //     {
            //         kin += lindex + ", ";
            //     }
            //     Console.WriteLine(kin);
            // }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        return listOfDoubleArrays;
    }

    static void Main(string[] args)
    {
        // Just in case I need it
        Random rand = new Random();

        // Get the two lists from the files
        List<double[]> testList = GetListFromFile("optdigits_test.txt");
        List<double[]> trainList = GetListFromFile("optdigits_train.txt");

        int maxGenerations = 20;
        var watch = Stopwatch.StartNew();

        // Loop through g generations
        for (int g = 0; g < maxGenerations; g++)
        {
            // Print generation num
            Console.WriteLine("GENERATION - " + (g + 1));

            // Define hidden layer sizes
            int[] hiddenLayers = new int[] {30, 15};

            // Creating a neural network with 64 inputs, 2 hidden layers, and 2 outputs
            NeuralNetwork myNetwork = new NeuralNetwork(64, hiddenLayers, 10);

            TrainData(trainList, myNetwork);

            // TestData(testList, myNetwork);
        }

        watch.Stop();
        Console.WriteLine("Elapsed Time: " + watch.ElapsedMilliseconds);    
    }

    public static void TrainData (List<double[]> trainList, NeuralNetwork myNetwork) 
    {
        int numCorrect = 0;
        List<double> correctPercentages = new List<double>();
        // Train
        for (int h = 0; h < trainList.Count; h++) 
        {
            // put the input from the list into an array to pass to net
            double[] input = new double[64];
            for (int i = 0; i < 64; i++)
            {
                input[i] = trainList[h][i];
            }

            // Set the current answer
            double answer = trainList[h][64];

            // Process the input through the network
            double[] output = myNetwork.FeedForward(input, answer);

            double bestAnswer = 0.0;
            int bestAnswerIndex = 0;

            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] > bestAnswer) 
                {
                    bestAnswer = output[i];
                    bestAnswerIndex = i;
                }
            }

            if (bestAnswerIndex == answer)
            {
                //Console.WriteLine("Best Answer: " + bestAnswerIndex + " - Real Answer: " + answer + " - CORRECT");
                numCorrect++;
            }
        }
        
        double percent = (double)trainList.Count / (double)numCorrect;

        Console.WriteLine("Num Correct: " + numCorrect + " - " + percent.ToString("n2") + "%");
        correctPercentages.Add((double)trainList.Count / (double)numCorrect);
    }

    public static void TestData(List<double[]> testList, NeuralNetwork myNetwork) 
    {
        int numCorrect = 0;
        // TEST
        for (int h = 0; h < testList.Count; h++) 
        {
            // put the input from the list into an array to pass to net
            double[] input = new double[64];
            for (int i = 0; i < 64; i++)
            {
                input[i] = testList[h][i];
            }

            // Set the current answer
            double answer = testList[h][64];

            // Process the input through the network
            double[] output = myNetwork.FeedForward(input, answer);

            double bestAnswer = 0.0;
            int bestAnswerIndex = 0;

            for (int i = 0; i < output.Length; i++)
            {
                if (output[i] > bestAnswer) 
                {
                    bestAnswer = output[i];
                    bestAnswerIndex = i;
                }
            }

            if (bestAnswerIndex == answer)
            {
                //Console.WriteLine("Best Answer: " + bestAnswerIndex + " - Real Answer: " + answer + " - CORRECT");
                numCorrect++;
            }
        }
    }
}


