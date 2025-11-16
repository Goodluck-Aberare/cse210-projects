public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    // Constructor for single verse
    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    // Constructor for verse range
    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse == null)
            return $"{Book} {Chapter}:{StartVerse}";

        return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}
