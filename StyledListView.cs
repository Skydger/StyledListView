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

    public partial class StyledListView : System.Windows.Forms.ListView{


        public StyledListView( System.ComponentModel.IContainer container ){
            /// <summary>
            /// Required for Windows.Forms Class Composition Designer support
            /// </summary>
            container.Add(this);
            this.InitializeComponent();
            this.ShadeItems();
            base.Refresh();
        }

        public StyledListView(){
            InitializeComponent();
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
            //MessageBox.Show("fff");
            e.Item.BackColor = this.styles[(e.ItemIndex + 1) % this.styles.Count].BackgroundColor;
            e.Item.Font = this.styles[(e.ItemIndex + 1) % this.styles.Count].Font;
            //e.Item.ForeColor = this.styles[(e.ItemIndex + 1) % this.styles.Count].ForegroundColor;
            //e.Item.EnsureVisible();
            //this.ShadeItems();
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
                        lvi.BackColor = this.styles[ i++ % this.styles.Count].BackgroundColor;
                        lvi.Font = this.styles[i++ % this.styles.Count].Font;
                        //lvi.ForeColor = this.styles[i++ % this.styles.Count].ForegroundColor;
                        //lvi.Font = new Font(
                        lvi.UseItemStyleForSubItems = true;
                    }
                }
            }
            return;
        }

    }
}