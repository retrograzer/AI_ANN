class Program
{
    public static List<double[]> GetTestList () 
    {
        string filePath = "optdigits_train.txt";
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
        GetTestList();
        int[] hiddenLayers = new int[] {30, 15};

        // Creating a neural network with 64 inputs, 2 hidden layers, and 2 outputs
        NeuralNetwork myNetwork = new NeuralNetwork(64, hiddenLayers, 2);

        // Example input (64 elements, could be any double values)
        double[] input = new double[64];
        Random rand = new Random();
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = rand.Next(); // Random input values
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


