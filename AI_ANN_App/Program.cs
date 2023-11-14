class Program
{
    static void Main(string[] args)
    {
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


