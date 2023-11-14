public class Neuron
{
    public double[] Weights;
    public double Bias;

    public Neuron(int inputCount)
    {
        Weights = new double[inputCount];
        Random rand = new Random();
        for (int i = 0; i < inputCount; i++)
        {
            Weights[i] = rand.NextDouble(); // Random weights
        }
        Bias = rand.NextDouble(); // Random bias
    }

    public double FeedForward(double[] inputs)
    {
        double total = 0.0;
        for (int i = 0; i < inputs.Length; i++)
        {
            total += inputs[i] * Weights[i];
        }
        return Sigmoid(total + Bias);
    }

    private double Sigmoid(double x)
    {
        return 1 / (1 + Math.Exp(-x));
    }
}

public class Layer
{
    public Neuron[] Neurons;

    public Layer(int neuronCount, int inputCount)
    {
        Neurons = new Neuron[neuronCount];
        for (int i = 0; i < neuronCount; i++)
        {
            Neurons[i] = new Neuron(inputCount);
        }
    }

    public double[] FeedForward(double[] inputs)
    {
        double[] outputs = new double[Neurons.Length];
        for (int i = 0; i < Neurons.Length; i++)
        {
            outputs[i] = Neurons[i].FeedForward(inputs);
        }
        return outputs;
    }
}

public class NeuralNetwork
{
    private Layer[] layers;

    public NeuralNetwork(int inputCount, int[] hiddenLayerCounts, int outputCount)
    {
        List<Layer> layerList = new List<Layer>();

        // Add the first hidden layer
        layerList.Add(new Layer(hiddenLayerCounts[0], inputCount));

        // Add additional hidden layers
        for (int i = 1; i < hiddenLayerCounts.Length; i++)
        {
            layerList.Add(new Layer(hiddenLayerCounts[i], hiddenLayerCounts[i - 1]));
        }

        // Add the output layer
        layerList.Add(new Layer(outputCount, hiddenLayerCounts.Last()));

        layers = layerList.ToArray();
    }

    public double[] FeedForward(double[] inputs)
    {
        double[] outputs = inputs;
        foreach (var layer in layers)
        {
            outputs = layer.FeedForward(outputs);
        }
        return outputs;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a neural network with 64 inputs, 2 hidden layers, and 2 outputs
        NeuralNetwork myNetwork = new NeuralNetwork(64, new int[] { 30, 15 }, 2);

        // Example input (64 elements, could be any double values)
        double[] input = new double[64];
        Random rand = new Random();
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = rand.NextDouble(); // Random input values
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


