using System;
using System.Collections.Generic;

#pragma warning disable CA1305
#pragma warning disable S1199
#pragma warning disable CA1304

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{source} is empty");
            }

            Dictionary<char, string> arr = new Dictionary<char, string>()
            {
                { '0', "zero" }, { '1', "one" }, { '2', "two" }, { '3', "three" }, { '4', "four" }, { '5', "five" }, { '6', "six" },
                { '7', "seven" }, { '8', "eight" }, { '9', "nine" }, { '.', "point" }, { '-', "minus" }, { ',', "point" }, { 'E', "E plus" },
            };

            List<string> res2 = new List<string>();
            List<string> res = new List<string>();
            var b = new List<string>();
            for (int h = 0; h < source.Length; h++)
            {
                if (double.IsNaN(source[h]))
                {
                    res.Add("Not a Number");
                }
                else if (double.IsPositiveInfinity(source[h]))
                {
                    res.Add("Positive Infinity");
                }
                else if (double.IsNegativeInfinity(source[h]))
                {
                    res.Add("Negative Infinity");
                }
                else if (source[h] == double.MaxValue)
                { 
                    res.Add("One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight");
                }
                else if (source[h] == double.MinValue)
                {
                    res.Add("Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight");
                }
                else if (source[h] == double.Epsilon)
                {
                    res.Add("Double Epsilon");
                }
                else
                {
                    for (int i = 0; i < source.Length; i++)
                    {
                        b.Add(source[i].ToString());
                    }

                    List<string> arr2 = new List<string>();
                    for (int i = 0; i < b.Count; i++)
                    {
                        var c = b[i].ToCharArray();
                        for (int j = 0; j < c.Length; j++)
                        {
                            foreach (var g in arr)
                            {
                                if (c[j] == g.Key)
                                {
                                    {
                                        arr2.Add(g.Value);
                                    }
                                }
                            }
                        }

                        var k = string.Join(' ', arr2);
                        var temp = k.ToCharArray();
                        temp[0] = char.ToUpper(temp[0]);
                        k = new string(temp);
                        arr2.Clear();
                        res2.Add(k);
                    }

                    return res2.ToArray();
                }
            }

            return res.ToArray();
        }
    }
}
