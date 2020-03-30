﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1.Classes
{
    public class Constructor
    {
        public void Select(MouseEventArgs e, List<Vertex> V, List<Edge> E, DrawGraph G, PictureBox sheet, int n = 0)
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (Math.Pow((V[i].x - e.X / Main.zoom), 2) + Math.Pow((V[i].y - e.Y / Main.zoom), 2) <= G.R * G.R)
                {
                    if (Main.selected1 != -1)
                    {
                        Main.selected1 = -1;
                        G.clearSheet();
                        if (n != 0) G.drawALLGraph(Main.V, Main.E);
                        G.drawALLGraph(V, E, n);
                        sheet.Image = G.GetBitmap();
                        Main.DrawGrid();
                    }
                    if (Main.selected1 == -1)
                    {
                        G.drawSelectedVertex(V[i].x, V[i].y);
                        Main.selected1 = i;
                        sheet.Image = G.GetBitmap();
                        Main.DrawGrid();
                        //createAdjAndOut();
                        //listBoxMatrix.Items.Clear();
                        //int degree = 0;
                        //for (int j = 0; j < routeV.Count; j++)
                        //    degree += AMatrix[selected1, j];
                        //listBoxMatrix.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                        break;
                    }
                }
            }
        }

        public void drawVertex(MouseEventArgs e, List<Vertex> V, DrawGraph G, PictureBox sheet)
        {
            V.Add(new Vertex(e.X / Main.zoom, e.Y / Main.zoom));
            G.drawVertex(e.X / Main.zoom, e.Y / Main.zoom, V.Count.ToString());
            sheet.Image = G.GetBitmap();
            Main.DrawGrid();
        }


        public void drawEdge(MouseEventArgs e, List<Vertex> V, List<Edge> E, DrawGraph G, PictureBox sheet, int n)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X / Main.zoom), 2) + Math.Pow((V[i].y - e.Y / Main.zoom), 2) <= G.R * G.R)
                    {
                        if (Main.selected1 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            Main.selected1 = i;
                            sheet.Image = G.GetBitmap();
                            break;
                        }
                        if (Main.selected2 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            Main.selected2 = i;
                            E.Add(new Edge(Main.selected1, Main.selected2));
                            G.drawEdge(V[Main.selected1], V[Main.selected2], E[E.Count - 1], n);
                            Main.selected1 = -1;
                            Main.selected2 = -1;
                            G.clearSheet();
                            if (n != 0) G.drawALLGraph(Main.V, Main.E);
                            G.drawALLGraph(V, E, n);
                            Main.DrawGrid();
                            sheet.Image = G.GetBitmap();
                            break;
                        }
                    }
                }
            }
            //if (e.Button == MouseButtons.Right)
            //{
            //    if ((Main.selected1 != -1) &&
            //        (Math.Pow((V[Main.selected1].x - e.X), 2) + Math.Pow((V[Main.selected1].y - e.Y), 2) <= G.R * G.R))
            //    {
            //        G.drawVertex(V[Main.selected1].x, V[Main.selected1].y, (Main.selected1 + 1).ToString());
            //        Main.selected1 = -1;
            //        sheet.Image = G.GetBitmap();
            //    }
            //}
        }

        public void drawEdgeRoute(MouseEventArgs e, List<Vertex> V, List<Edge> E, DrawGraph G, PictureBox sheet, int n)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X / Main.zoom), 2) + Math.Pow((V[i].y - e.Y / Main.zoom), 2) <= G.R * G.R)
                    {
                        if (Main.selected1 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            V.Add(new Vertex(V[i].x / Main.zoom, V[i].y / Main.zoom));
                            Main.selected1 = i;
                            sheet.Image = G.GetBitmap();
                            break;
                        }
                        if (Main.selected2 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            Main.selected2 = i;
                            V.Add(new Vertex(V[i].x / Main.zoom, V[i].y / Main.zoom));
                            E.Add(new Edge(V.Count - 2, V.Count - 1));
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            Main.selected2 = i;
                            E.Add(new Edge(Main.selected1, Main.selected2));
                            for (var j = 0; j < Main.E.Count; i++)
                            {
                                foreach (var z in Main.edgePoints[n])
                                {
                                    if (Main.E[j].v1 == z.v1 && Main.E[j].v2 == z.v2)
                                    {
                                        G.drawEdge(V[Main.selected1], V[Main.selected2], E[E.Count - 1], n);
                                        sheet.Image = G.GetBitmap();
                                        Main.selected1 = -1;
                                        Main.selected2 = -1;
                                        break;
                                    }
                                }
                            };
                            E.Remove(E.Last());
                            G.clearSheet();
                            Main.DrawGrid();
                            sheet.Image = G.GetBitmap();
                            Main.selected1 = -1;
                            Main.selected2 = -1;
                            //routesEdge[int.Parse(comboBox1.Text)].Add(new Edge(routeV.Count - (routeV.Count / 2 + 1), routeV.Count - (routeV.Count / 2)));
                            //G.drawEdge(routeV[routeV.Count - 2], routeV[routeV.Count - 1], routesEdge[int.Parse(comboBox1.Text)][routesEdge[int.Parse(comboBox1.Text)].Count - 1], 0, 1);
                            //G.drawALLGraph(routeV, routesEdge[int.Parse(changeRoute.Text)], 1);
                            //selected1 = -1;
                            //selected2 = -1;
                            //sheet.Image = G.GetBitmap();
                            //        CreateOneRouteCoordinates(int.Parse(comboBox1.Text));
                            break;
                        }
                    }
                }
            }
            //if (e.Button == MouseButtons.Right)
            //{
            //    //G.drawALLGraph(routeV, routesEdge[int.Parse(comboBox1.Text)], 1);
            //    //selected1 = -1;
            //    //selected2 = -1;
            //    if ((selected1 != -1) &&
            //        (Math.Pow((routeV[selected1].x - e.X), 2) + Math.Pow((routeV[selected1].y - e.Y), 2) <= G.R * G.R))
            //    {
            //        G.drawVertex(routeV[selected1].x, routeV[selected1].y, (selected1 + 1).ToString());
            //        selected1 = -1;
            //        sheet.Image = G.GetBitmap();
            //        //    CreateOneRouteCoordinates(int.Parse(comboBox1.Text));
            //    }
            //}
        }

        public async void del(MouseEventArgs e, List<Vertex> V, List<Edge> E, PictureBox sheet, DrawGraph G, SerializableDictionary<int, List<Edge>> routesEdgeE)
        {
            await Task.Run(() => delete(e, V, E, sheet, G, routesEdgeE));
        }
        public void delete(MouseEventArgs e, List<Vertex> V, List<Edge> E, PictureBox sheet, DrawGraph G, SerializableDictionary<int, List<Edge>> routesEdgeE)
        {
            //удалили ли что-нибудь по ЭТОМУ клику
            //ищем, возможно была нажата вершина
            Main.flag = false;

            foreach (var tl in Main.traficLights)
            {
                if (Math.Pow((tl.x - e.X / Main.zoom), 2) + Math.Pow((tl.y - e.Y / Main.zoom), 2) <= G.R * G.R)
                {
                    tl.Stop();
                    Main.traficLights.Remove(tl);                    
                    break;
                }
            }

            //foreach()

            foreach(var sp in Main.allstopPoints)
            {
                if (Math.Pow((sp.x - e.X / Main.zoom), 2) + Math.Pow((sp.y - e.Y / Main.zoom), 2) <= G.R * G.R)
                {
                    Main.allstopPoints.Remove(sp);
                    break;
                }
            }

            foreach (var routeV in Main.routes)
            {
                for (int i = 0; i < routeV.Value.Count; i++)
                {
                    if (Math.Pow((routeV.Value[i].x - e.X / Main.zoom), 2) + Math.Pow((routeV.Value[i].y - e.Y / Main.zoom), 2) <= G.R * G.R)
                    {
                        //foreach(var routesEdge in routesEdgeE.Values)
                        //{
                        for (int j = 0; j < routesEdgeE[routeV.Key].Count; j++)
                        {
                            if ((routesEdgeE[routeV.Key][j].v1 == i) || (routesEdgeE[routeV.Key][j].v2 == i))
                            {
                                routesEdgeE[routeV.Key].RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (routesEdgeE[routeV.Key][j].v1 > i) routesEdgeE[routeV.Key][j].v1--;
                                if (routesEdgeE[routeV.Key][j].v2 > i) routesEdgeE[routeV.Key][j].v2--;
                            }
                        }
                        routeV.Value.RemoveAt(i);
                        Main.flag = true;
                        break;
                        //}                       
                    }

                }
            }
            //ищем, возможно было нажато ребро
            if (!Main.flag)
            {
                foreach (var routeV in Main.routes)
                {
                    for (int j = 0; j < routeV.Value.Count; j++)
                    {
                        for (int i = 0; i < routesEdgeE[routeV.Key].Count; i++)
                        {
                            if (routesEdgeE[routeV.Key][i].v1 == routesEdgeE[routeV.Key][i].v2) //если это петля
                            {
                                if ((Math.Pow((routeV.Value[routesEdgeE[routeV.Key][i].v1].x - G.R - e.X), 2) + Math.Pow((routeV.Value[routesEdgeE[routeV.Key][i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                    (Math.Pow((routeV.Value[routesEdgeE[routeV.Key][i].v1].x - G.R - e.X), 2) + Math.Pow((routeV.Value[routesEdgeE[routeV.Key][i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                                {
                                    routesEdgeE[routeV.Key].RemoveAt(i);
                                    Main.flag = true;
                                    break;
                                }
                            }
                            //else //не петля
                            //{
                            //    if (((e.X - routeV[routesEdgeE[routeV.Key][i].v1].x) * (routeV[routesEdgeE[routeV.Key][i].v2].y - routeV[routesEdgeE[routeV.Key][i].v1].y) / (routeV[routesEdgeE[routeV.Key][i].v2].x - routeV[routesEdgeE[routeV.Key][i].v1].x) + routeV[routesEdgeE[routeV.Key][i].v1].y) <= (e.Y + 4) &&
                            //        ((e.X - routeV[routesEdgeE[routeV.Key][i].v1].x) * (routeV[routesEdgeE[routeV.Key][i].v2].y - routeV[routesEdgeE[routeV.Key][i].v1].y) / (routeV[routesEdgeE[routeV.Key][i].v2].x - routeV[routesEdgeE[routeV.Key][i].v1].x) + routeV[routesEdgeE[routeV.Key][i].v1].y) >= (e.Y - 4))
                            //    {
                            //        if ((routeV[routesEdgeE[routeV.Key][i].v1].x <= routeV[routesEdgeE[routeV.Key][i].v2].x && routeV[routesEdgeE[routeV.Key][i].v1].x <= e.X && e.X <= routeV[routesEdgeE[routeV.Key][i].v2].x) ||
                            //            (routeV[routesEdgeE[routeV.Key][i].v1].x >= routeV[routesEdgeE[routeV.Key][i].v2].x && routeV[routesEdgeE[routeV.Key][i].v1].x >= e.X && e.X >= routeV[routesEdgeE[routeV.Key][i].v2].x))
                            //        {
                            //            routesEdgeE[routeV.Key].RemoveAt(i);
                            //            Main.flag = true;
                            //            break;
                            //        }
                            //    }
                            //}
                        }

                    }
                }
            }

            for (int i = 0; i < V.Count; i++)
            {
                if (Math.Pow((V[i].x - e.X / Main.zoom), 2) + Math.Pow((V[i].y - e.Y / Main.zoom), 2) <= G.R * G.R)
                {
                    for (int j = 0; j < E.Count; j++)
                    {
                        if ((E[j].v1 == i) || (E[j].v2 == i))
                        {

                            E.RemoveAt(j);
                            //Console.WriteLine(routesEdge);
                            //foreach(var re in routesEdge)
                            //{
                            //    foreach(var r in re.Value)
                            //    {
                            //        if (r.v1 == E[j].v1 && r.v2 == E[j].v2)
                            //        {
                            //            re.Value.Remove(r);
                            //            break;
                            //        };
                            //    };
                            //};
                            j--;
                        }
                        else
                        {
                            if (E[j].v1 > i) E[j].v1--;
                            if (E[j].v2 > i) E[j].v2--;
                        }
                    }
                    //int er = 0;
                    //foreach (var route in Main.routes)
                    //{
                    //    er = 0;
                    //    foreach (var r in route.Value)
                    //    {

                    //        foreach (var rp in Main.routePoints)
                    //        {
                    //            if (rp.ContainsKey(i))
                    //            {

                    //                if (r.x == rp[i].x && r.y == rp[i].y)
                    //                {
                    //                    //       routesEdgeE[5].Remove(i);
                    //                    // Console.WriteLine(routesEdgeE);                                                                    
                    //                    //for (int w = 0; w < routesEdgeE[23].Count; w++)
                    //                    //{
                    //                    //    if ((routesEdgeE[23][w].v1 == i) || (routesEdgeE[23][w].v2 == i))
                    //                    //    {
                    //                    //        routesEdgeE[23].RemoveAt(w);
                    //                    //        w--;
                    //                    //    }
                    //                    //    else
                    //                    //    {
                    //                    //        if (routesEdgeE[23][w].v1 > i) routesEdgeE[23][w].v1--;
                    //                    //        if (routesEdgeE[23][w].v2 > i) routesEdgeE[23][w].v2--;
                    //                    //    }

                    //                    //}
                    //                    route.Value.Remove(r);
                    //                    er = 1;
                    //                    //break;
                    //                };
                    //            }
                    //        }
                    //        if (er == 1)
                    //        {
                    //            break;
                    //        };
                    //    };
                    //};
                    V.RemoveAt(i);


                    Main.flag = true;
                    //       DrawGrid();
                    break;

                }

            }

            //ищем, возможно было нажато ребро
            if (!Main.flag)
            {
                for (int i = 0; i < E.Count; i++)
                {
                    if (E[i].v1 == E[i].v2) //если это петля
                    {
                        if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                            (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                        {
                            E.RemoveAt(i);
                            Main.flag = true;
                            //  DrawGrid();
                            break;
                        }
                    }
                    //else //не петля
                    //{
                    //    if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                    //        ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                    //    {
                    //        if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                    //            (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                    //        {
                    //            E.RemoveAt(i);
                    //            Main.flag = true;
                    //            Main.DrawGrid();
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }
            //если что-то было удалено, то обновляем граф на экране
            //if (Main.flag)
            //{
            //    G.clearSheet();
            //    G.drawALLGraph(V, E);
            //    //  G.drawALLGraph(V, E, 1);
            //    sheet.Image = G.GetBitmap();
            //    Main.DrawGrid();
            //}
            // return routesEdgeE;
        }

        public void deleteRoute(MouseEventArgs e, List<Vertex> routeV, List<Edge> routesEdge, PictureBox sheet, DrawGraph G)
        {
            bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                               //ищем, возможно была нажата вершина
            for (int i = 0; i < routeV.Count; i++)
            {
                if (Math.Pow((routeV[i].x - e.X / Main.zoom), 2) + Math.Pow((routeV[i].y - e.Y / Main.zoom), 2) <= G.R * G.R)
                {
                    for (int j = 0; j < routesEdge.Count; j++)
                    {
                        if ((routesEdge[j].v1 == i) || (routesEdge[j].v2 == i))
                        {
                            routesEdge.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (routesEdge[j].v1 > i) routesEdge[j].v1--;
                            if (routesEdge[j].v2 > i) routesEdge[j].v2--;
                        }
                    }
                    routeV.RemoveAt(i);
                    flag = true;
                    //  DrawGrid();
                    break;
                }
                // DrawGrid();
            }
            //ищем, возможно было нажато ребро
            if (!flag)
            {
                for (int i = 0; i < routesEdge.Count; i++)
                {
                    if (routesEdge[i].v1 == routesEdge[i].v2) //если это петля
                    {
                        if ((Math.Pow((routeV[routesEdge[i].v1].x - G.R - e.X), 2) + Math.Pow((routeV[routesEdge[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                            (Math.Pow((routeV[routesEdge[i].v1].x - G.R - e.X), 2) + Math.Pow((routeV[routesEdge[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                        {
                            routesEdge.RemoveAt(i);
                            flag = true;
                            //   DrawGrid();
                            break;
                        }
                    }
                    //else //не петля
                    //{
                    //    if (((e.X - routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x) * (routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].y - routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].y) / (routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].x - routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x) + routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].y) <= (e.Y + 4) &&
                    //        ((e.X - routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x) * (routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].y - routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].y) / (routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].x - routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x) + routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].y) >= (e.Y - 4))
                    //    {
                    //        if ((routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x <= routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].x && routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x <= e.X && e.X <= routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].x) ||
                    //            (routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x >= routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].x && routeV[routesEdge[int.Parse(comboBox1.Text)][i].v1].x >= e.X && e.X >= routeV[routesEdge[int.Parse(comboBox1.Text)][i].v2].x))
                    //        {
                    //            routesEdge[int.Parse(comboBox1.Text)].RemoveAt(i);
                    //            flag = true;
                    //            DrawGrid();
                    //            break;
                    //        }
                    //    }
                    //}
                }
            }
            //если что-то было удалено, то обновляем граф на экране
            if (flag)
            {
                G.clearSheet();
                G.drawALLGraph(Main.V, Main.E);
                G.drawALLGraph(routeV, routesEdge, 1);
                sheet.Image = G.GetBitmap();
                Main.DrawGrid();
            }
        }

    }
}
