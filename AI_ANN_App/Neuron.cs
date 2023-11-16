public class Node
{
    // All the weights of this node
    public double[] Weights;
    
    // Bias will always be 1 but I want a way to control it
    public double Bias;

    // I'm just keeping track of depth for cout purposes
    public int Depth;

    public Node(int inputCount, int depth)
    {
        Weights = new double[inputCount];
        Random rand = new Random();
        for (int i = 0; i < inputCount; i++)
        {
            var rD = rand.NextDouble();
            Weights[i] = rD * (0.009 - 0.001) + 0.001; // Random weights between 0.009 and 0.001
        }
        Bias = 1.0;
        Depth = depth;
        // Console.WriteLine("Depth of this node: " + Depth + " - Weight Count: " + Weights.Length);
    }

    public double FeedForward(double[] inputs, double answer)
    {
        double total = 0.0;
        for (int i = 0; i < inputs.Length; i++)
        {
            total += inputs[i] * Weights[i];
        }
        if (Depth == 2) 
        {
            //Console.WriteLine("Total: " + total);
            //Console.WriteLine("Output Thing: " + answer);
        }
        return Sigmoid(total + Bias);
    }

    private double Sigmoid(double x)
    {
        return 1 / (1 + Math.Exp(-x));
    }
}