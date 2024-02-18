public void Plain()
{
    var a = new int[10];
    var b = new int[3] { a[0], a[1], a[2] };
    PlainChange(b);
    a[0] = b[0];
    a[1] = b[1];
    a[2] = b[2];
}

private void PlainChange(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = -1;
    }
}

public void Span()
{
    var a = new int[10];
    SpanChange(a.AsSpan(0, 3));
}

private void SpanChange(Span<int> span)
{
    for (int i = 0; i < span.Length; i++)
    {
        span[i] = -1;
    }
}
