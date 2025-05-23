public static class DepthSeparator
{
    private static readonly string _separators = "⓿❶❷❸❹❺❻❼❽❾❿⓫⓬⓭⓮⓯⓰⓱⓲⓳⓴";
    private static readonly string _arraySeparator = "①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳";

    public static char GetSeparator(int depth)
    {
        return _separators[depth];
    }

    public static char GetArraySeparator(int depth)
    {
        return _arraySeparator[depth];
    }
}