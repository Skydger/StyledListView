using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace StyledControls
{
    public delegate void NewItemAdded(int index, System.Windows.Forms.ListViewItem item);
    //public delegate void NewItemsAdded(int index, System.Windows.Forms.ListViewItem item);

    public partial class StyledListView : System.Windows.Forms.ListView{


        public StyledListView( System.ComponentModel.IContainer container ){
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>
            //this.container.Add(this);
            this.InitializeComponent();
            this.ShadeItems();
            base.Refresh();
        }

        public StyledListView(){
            this.InitializeComponent();
            base.Refresh();
        }

        //protected override void ColumnClick(EventArgs e){
        //    base.OnPaint(e);

        //    this.ShadeItems();
        //}

        //protected override void OnItemActivate(EventArgs e)
        //{
        //    base.OnItemActivate(e);
        //    this.ShadeItems();
        //}

        //public override void Refresh(){
 	    //    base.Refresh();
        //    this.ShadeItems();
        //}
        //    base.OnDrawItem(e);
        //    //e.
        //    e.Item.BackColor = this.styles[ (e.ItemIndex + 1) % this.styles.Count].Color;
        //    e.DrawFocusRectangle();
        //}
        public void OnNewItemAdded(int index, System.Windows.Forms.ListViewItem item){
            if ((this.styles.Count > 0) && (item != null)){
                item.BackColor = this.styles[(index + 1) % this.styles.Count].BackgroundColor;
                item.UseItemStyleForSubItems = true;
                this.Refresh();
            }
            return;
        }

        private void DrawShadedItem(object sender, DrawListViewItemEventArgs e)
        {
            //base.OnDrawItem(e);
            e.Item.BackColor = this.styles[(e.ItemIndex + 1) % this.styles.Count].BackgroundColor;
            e.Item.Font = this.styles[(e.ItemIndex + 1) % this.styles.Count].Font;
            e.Item.ForeColor = this.styles[(e.ItemIndex + 1) % this.styles.Count].ForegroundColor;
        }

        private void OnColunmClickSort(object sender, ColumnClickEventArgs e){
            if (e.Column == this.sorter.SortColumn){
                // Reverse the current sort direction for this column.
                if (this.sorter.Order == SortOrder.Ascending){
                    this.sorter.Order = SortOrder.Descending;
                }else{
                    this.sorter.Order = SortOrder.Ascending;
                }
            }else{
                // Set the column number that is to be sorted; default to ascending.
                this.sorter.SortColumn = e.Column;
                this.sorter.Order = SortOrder.Ascending;
            }
            // Perform the sort with these new sort options.
            this.Sort();
            this.ShadeItems();
            return;
        }

        protected override void OnResize(EventArgs e){
 	        base.OnResize(e);
            this.ShadeItems();
        }

        public override void Refresh()
        {
            this.ShadeItems();
            base.Refresh();

        }

        public void ShadeItems(){
            if( this.styles.Count > 0 ){
                int i = 0;
                foreach (System.Windows.Forms.ListViewItem lvi in this.Items){
                    //MessageBox.Show("code " + i.ToString() + " " + styles[i-1].Color.ToString() );
                    if( lvi != null){
                        // saving default color
                        System.Drawing.Color df_bkcolor = lvi.BackColor;
                        System.Drawing.Color df_fgcolor = lvi.ForeColor;
                        System.Drawing.Font df_font = lvi.Font;
                        
                        StyledControls.Style style = this.styles[ i++ % this.styles.Count];
                        lvi.BackColor = style.BackgroundColor;
                        lvi.Font = style.Font;
                        lvi.ForeColor = style.ForegroundColor;
                        lvi.UseItemStyleForSubItems = style.UseFullRow;
                    }
                }
            }
            return;
        }

    }
}