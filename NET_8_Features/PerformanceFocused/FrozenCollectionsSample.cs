#region Copyright Notice
/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2023 Dmytro Skryzhevskyi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
*/
#endregion
using System.Collections.Frozen;
using System.Drawing;

namespace NET_8_Features.PerformanceFocused;

public class FrozenCollectionsSample
{
    private Dictionary<Color, string> _values;
    private FrozenDictionary<Color, string> _fvalues;
    private FrozenSet<string> _fcollection;
    private List<string> _collection;

    private static string Hex(Color c)
    {
        return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    }

    private void Add(Color c)
    {
        _values.Add(c, Hex(c));
        _collection.Add(c.ToString());
    }

    public FrozenCollectionsSample()
    {
        _values = new Dictionary<Color, string>();
        _collection = new List<string>();
        Add(Color.Aqua);
        Add(Color.Azure);
        Add(Color.Black);
        Add(Color.Blue);
        Add(Color.Chocolate);
        Add(Color.Aquamarine);
        Add(Color.Beige);
        Add(Color.Coral);
        Add(Color.Firebrick);
        Add(Color.Cyan);
        _fvalues = _values.ToFrozenDictionary();
        _fcollection = _collection.ToFrozenSet();
    }

    public string GetFrozen(Color c)
    {
        _fvalues.TryGetValue(c, out var hex);
        return hex;
    }

    public string GetStd(Color c)
    {
        _values.TryGetValue(c, out var hex);
        return hex;
    }

    public string GetFrozenSet(Color c)
    {
        return _fcollection.FirstOrDefault(x => x == c.ToString());
    }

    public string GetStdList(Color c)
    {
        return _collection.FirstOrDefault(x => x == c.ToString());
    }
}