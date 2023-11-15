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
            Weights[i] = rand.NextDouble(); // Random weights
        }
        Bias = 1;
        Depth = depth;
        // Console.WriteLine("Depth of this node: " + Depth + " - Weight Count: " + Weights.Length);
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