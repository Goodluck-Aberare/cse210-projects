using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    private List<Word> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        _words = text.Split(" ").Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If no more visible words, return
        if (!visibleWords.Any()) return;

        for (int i = 0; i < count; i++)
        {
            if (!visibleWords.Any()) break;

            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{Reference}\n{text}";
    }
}
