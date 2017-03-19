public interface IMinHeap
{
    void Add(int newElement);
    void DecreaseKey(int oldElement, int newElement);
    void Delete(int element);
    int PopMin();
    int GetMin();
    int Count { get; }
}

public interface IMinHeap<T>
{
    void Add(T newElement);
    void DecreaseKey(T element, T newElement); //strange interface
    void Delete(T element);
    T PopMin();
    T GetMin();
    int Count { get; }
}