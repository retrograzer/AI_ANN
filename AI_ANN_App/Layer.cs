public class Layer
{
    public Node[] Node;
    public int layerDepth;

    public Layer(int neuronCount, int inputCount, int layerDepth)
    {
        Node = new Node[neuronCount];
        for (int i = 0; i < neuronCount; i++)
        {
            Node[i] = new Node(inputCount, layerDepth);
        }
    }

    public double[] FeedForward(double[] inputs, double answer)
    {
        double[] outputs = new double[Node.Length];
        for (int i = 0; i < Node.Length; i++)
        {
            outputs[i] = Node[i].FeedForward(inputs, answer);
        }
        return outputs;
    }
}