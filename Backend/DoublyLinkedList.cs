namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;
    private bool _isDescending;

    public bool IsDescending { get; set; }

    // Inserts a new node into the list keeping the current sort order
    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);

        // Empty list initialization
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            _isDescending = false;
            return;
        }

        var current = _head;

        // Search correct insertion position based on current order
        if (!_isDescending)
        {
            while (current != null && current.Data!.CompareTo(data) < 0)
                current = current.Next;
        }
        else
        {
            while (current != null && current.Data!.CompareTo(data) > 0)
                current = current.Next;
        }

        // Insert at beginning
        if (current == _head)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        // Insert at end
        else if (current == null)
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        // Insert in middle
        else
        {
            newNode.Next = current;
            newNode.Prev = current.Prev;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
    }
        // Formats list contents from head to tail
    public string ToStringForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data},";
            current = current.Next;
        }
        return $"{output.TrimEnd(',')}\n";
    }

    // Formats list contents from tail to head
    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data},";
            current = current.Prev;
        }
        return $"{output.TrimEnd(',')} ";
    }

    // Reverses node pointers to toggle ascending/descending order
    public void OrderDescending()
    {
        if (_head == null || _head.Next == null) return;

        var current = _head;
        DoubleNode<T>? temp = null;

        // Swap Next and Prev pointers for all nodes
        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev; // Advance using Prev after swapping
        }

        // Swap head and tail pointers
        temp = _head;
        _head = _tail;
        _tail = temp;

        _isDescending = !_isDescending;
    }
    // Checks if an element exists in the list
    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Calculates and returns string representation of statistical mode(s)
    public string GetModes()
    {
        if (_head == null) return string.Empty;

        var frequencies = GetFrequencies();
        int maxFreq = frequencies.Values.Max();

        var modes = frequencies.Where(kvp => kvp.Value == maxFreq).Select(kvp => kvp.Key.ToString());

        // Single mode identified
        if (modes.Count() == 1)
            return $"The mode is {modes.First()}.";
        // Multiple modes identified
        else
            return $"The modes are {string.Join(" and ", modes)}.";
    }

    // Counts element frequency occurrences across the list
    private Dictionary<T, int> GetFrequencies()
    {
        var frequencies = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data!))
                frequencies[current.Data!]++;
            else
                frequencies[current.Data!] = 1;

            current = current.Next;
        }
        return frequencies;
    }

    // Builds text histogram lines using asterisks
    public List<string> GetGraph()
    {
        var graphLines = new List<string>();
        if (_head == null) return graphLines;

        var frequencies = GetFrequencies();
        var keys = frequencies.Keys.ToList();
        keys.Sort();

        foreach (var key in keys)
        {
            graphLines.Add($"{key} {new string('*', frequencies[key])}");
        }

        return graphLines;
    }

    // Removes and returns the first element in the list
    public T? RemoveFirst()

    {
        if (_head == null) return default;

        var removedData = _head.Data;

        // Single element case
        if (_head.Next == null)
        { }

        // Multiple elements case
        else
        {
            _head = _head.Next;
            _head!.Prev = null;
        }

        return removedData;
    }

    // Resets the list to empty
    public void Clear()
    {
        _head = null;
        _tail = null;
    }
}