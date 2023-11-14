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
        Bias = 1; // Random bias
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