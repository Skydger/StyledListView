namespace StyledControls
{
    partial class StyledListView : System.Windows.Forms.ListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private StylesCollection styles = null;
        private ListViewItemsCollection items = null;

        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public StylesCollection Styles{
            get { return this.styles; }
            set { this.styles = value; }
        }

        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        new public System.Windows.Forms.ListView.ListViewItemCollection Items{
            get { return (System.Windows.Forms.ListView.ListViewItemCollection)this.items; }
            set { this.items = (ListViewItemsCollection)value; }
        }
        //new public ListViewItemsCollection Items{
        //    get { return this.items; }
        //    set { this.items = value; }
        //}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //this.SuspendLayout();
            // 
            // StyledListView
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.Name = "StyledListView";
            //this.Size = new System.Drawing.Size(326, 87);
            //this.ResumeLayout(false);
            this.components = new System.ComponentModel.Container();
            this.styles = new StylesCollection();
            this.items = new ListViewItemsCollection(this, this.OnNewItemAdded);
            //this.OnDrawItem += 
            this.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.DrawShadedItem);
        }

        #endregion
    }
}
