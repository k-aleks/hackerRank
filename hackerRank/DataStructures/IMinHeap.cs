public interface IMinHeap
{
    void Add(int newElement);
    void DecreaseKey(int oldElement, int newElement);
    void Delete(int element);
    int PopMin();
    int GetMin();
    int Count { get; }
}