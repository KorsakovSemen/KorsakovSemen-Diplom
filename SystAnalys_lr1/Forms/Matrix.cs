﻿using MetroFramework.Forms;
using SystAnalys_lr1.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    public partial class Main : MetroForm
    {
        public List<Bus> BubbleSortEx(List<Bus> buses)
        {
            var temp = new Bus();
            for (int i = 0; i < buses.Count - 1; i++)
            {
                for (int j = 0; j < buses.Count - i - 1; j++)
                {
                    if (buses[j + 1].route == buses[j].route && buses[j + 1].tracker == true && buses[j].tracker == false)
                    {
                        temp = buses[j + 1];
                        buses[j + 1] = buses[j];
                        buses[j] = temp;
                    };
                }
            }
            return buses;
        }

        SortedDictionary<string, List<Vertex>> routesSorted;

        private void Matrix()
        {
            matrixGrid.Rows.Clear();
            matrixGrid.Refresh();

            buses.Sort((a1, b1) => a1.route.CompareTo(b1.route));

            SplitBuses();

            routesSorted = new SortedDictionary<string, List<Vertex>>(routes);

            foreach (var x in routes)
            {
                if (x.Value.Count == 0)
                {
                    routesSorted.Remove(x.Key);
                }
            }

            int parkSize = 0;

            foreach (var x in busesPark)
            {
                parkSize = Math.Max(parkSize, x.Count);
            }

            int[,] myArr = new int[routesSorted.Count, parkSize];

            if (routesSorted.Count == 0)
                matrixGrid.RowCount = 1;
            else
                matrixGrid.RowCount = routesSorted.Count;
            matrixGrid.ColumnCount = parkSize + 1;

            for (int i = 1; i < parkSize; i++)
            {
                matrixGrid.Columns[i - 1].HeaderText = i.ToString();
                if (i + 1 == parkSize)
                {
                    matrixGrid.Columns[i].HeaderText = parkSize.ToString();
                }
            }

            matrixGrid.Columns[parkSize].HeaderText = "Total";

            for (int i = 0; i < busesPark.Count; ++i)
            {
                if (busesPark[i].Count != 0)
                {
                    matrixGrid.Rows[i].HeaderCell.Value = busesPark[i].First().route.ToString();
                }
            }

            int total, res;
            res = 0;
            for (int i = 0; i < busesPark.Count; i++)
            {
                total = 0;
                for (int j = 0; j < parkSize + 1; j++)
                {
                    if (j < busesPark[i].Count)
                    {
                        if (busesPark[i][j].tracker == true)
                        {
                            myArr[i, j] = 1;
                            total++;
                        }
                        else
                        {
                            myArr[i, j] = 0;
                        }
                        matrixGrid.Rows[i].Cells[j].Value = myArr[i, j];
                    }
                    else
                    {
                        matrixGrid.Rows[i].Cells[j].Value = 0;
                    }
                    matrixGrid.Rows[i].Cells[parkSize].Value = total;

                }
                res += total;
            }

            label8.Text = MainStrings.matrixFirst + res.ToString() + " " + MainStrings.matrixSecond + (buses.Count - res).ToString() + " " + MainStrings.matrixThird + buses.Count.ToString();
        }
    }
}
