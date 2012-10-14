using System;
using System.Collections.Generic;
using System.Text;

namespace StyledControls
{
    public class ListViewItemsShader{
        public static void ShadeItem(System.Windows.Forms.ListViewItem inListViewItem, System.Drawing.Color color, System.Drawing.Color shade_color){
            if (inListViewItem.Index % 2 == 0){
                inListViewItem.BackColor = color;
            }else{
                inListViewItem.BackColor = shade_color;
            }
            inListViewItem.UseItemStyleForSubItems = true;
            return;
        }
        public static void ShadeItems(System.Windows.Forms.ListView inListView, System.Drawing.Color color, System.Drawing.Color shade_color){
            int i = 0;
            foreach (System.Windows.Forms.ListViewItem lvi in inListView.Items){
                if (++i % 2 == 0){
                    lvi.BackColor = color;
                }else{
                    lvi.BackColor = shade_color;
                }
                lvi.UseItemStyleForSubItems = true;
            }
            return;
        }
    }
}
