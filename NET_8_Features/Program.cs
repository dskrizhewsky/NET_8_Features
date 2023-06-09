﻿#region Copyright Notice

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

using System.Text.Json;
using NET_8_Features.Alias;
using NET_8_Features.Randomness;
using NET_8_Features.Serialization;

var colors = GetItemsSample.GetRandomColors(10);
GetItemsSample.Print(colors);
GetItemsSample.Shuffle(colors);
Console.WriteLine("Shuffled");
GetItemsSample.Print(colors);

var als = new AliasSample();

Console.WriteLine(als.Calc(1, 1, opType.Plus));
Console.WriteLine(als.Calc(10, 1, opType.Minus));
Console.WriteLine(als.Calc(10, 5, opType.Div));
Console.WriteLine(als.Calc(10, 2, opType.Mult));

IEmployee emp = new Employee("sample text", "David", "XYZ ltd");
var json = JsonSerializer.Serialize(emp);
Console.WriteLine(json);
json = JsonSerializer.Serialize(emp as Employee);
Console.WriteLine(json);
var newEmp = JsonSerializer.Deserialize<Employee>(json);
Console.WriteLine($"Read-only property: {newEmp.Memo}");