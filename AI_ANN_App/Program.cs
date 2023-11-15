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

        // Define hidden layer sizes
        int[] hiddenLayers = new int[] {30, 15};

        // Creating a neural network with 64 inputs, 2 hidden layers, and 2 outputs
        NeuralNetwork myNetwork = new NeuralNetwork(64, hiddenLayers, 2);

        // put the input from the list into an array to pass to net
        double[] input = new double[64];
        for (int i = 0; i < 64; i++)
        {
            input[i] = trainList[0][i]; // Random input values
        }

        // Process the input through the network
        double[] output = myNetwork.FeedForward(input);

        // Output the results
        Console.WriteLine("Output from the neural network:");
        foreach (var value in output)
        {
            Console.WriteLine(value);
        }
    }
}


