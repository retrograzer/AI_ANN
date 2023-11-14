public class NeuralNetwork
{
    private Layer[] layers;

    public NeuralNetwork(int inputCount, int[] hiddenLayerCounts, int outputCount)
    {
        List<Layer> layerList = new List<Layer>
        {
            // Add the first hidden layer
            new Layer(hiddenLayerCounts[0], inputCount)
        };

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