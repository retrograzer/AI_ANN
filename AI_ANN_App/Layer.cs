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