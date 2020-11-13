using System.Windows.Data;

namespace HSTS_RecipeManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtPrepTime = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.lblPrepTime = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtMethods = new System.Windows.Forms.TextBox();
            this.txtIngredients = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteStep = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnStepUp = new System.Windows.Forms.Button();
            this.btnNewStep = new System.Windows.Forms.Button();
            this.lbSteps = new System.Windows.Forms.ListBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtNumServes = new System.Windows.Forms.TextBox();
            this.lblNumServes = new System.Windows.Forms.Label();
            this.chkbox_fav = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.lvFavourite = new System.Windows.Forms.ListView();
            this.lblFav = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(256, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(458, 68);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(509, 369);
            this.dgvList.TabIndex = 3;
            this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            // 
            // txtPrepTime
            // 
            this.txtPrepTime.Location = new System.Drawing.Point(125, 161);
            this.txtPrepTime.Name = "txtPrepTime";
            this.txtPrepTime.Size = new System.Drawing.Size(256, 20);
            this.txtPrepTime.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(692, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(192, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // lblIngredients
            // 
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Location = new System.Drawing.Point(17, 205);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(59, 13);
            this.lblIngredients.TabIndex = 2;
            this.lblIngredients.Text = "Ingredients";
            // 
            // lblPrepTime
            // 
            this.lblPrepTime.AutoSize = true;
            this.lblPrepTime.Location = new System.Drawing.Point(21, 168);
            this.lblPrepTime.Name = "lblPrepTime";
            this.lblPrepTime.Size = new System.Drawing.Size(55, 13);
            this.lblPrepTime.TabIndex = 2;
            this.lblPrepTime.Text = "Prep Time";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(22, 275);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(48, 13);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "Methods";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDelete.Location = new System.Drawing.Point(292, 467);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSubmit.Location = new System.Drawing.Point(44, 467);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Save";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtMethods
            // 
            this.txtMethods.Location = new System.Drawing.Point(125, 272);
            this.txtMethods.Multiline = true;
            this.txtMethods.Name = "txtMethods";
            this.txtMethods.Size = new System.Drawing.Size(256, 20);
            this.txtMethods.TabIndex = 1;
            this.txtMethods.TextChanged += new System.EventHandler(this.txtMethods_TextChanged);
            // 
            // txtIngredients
            // 
            this.txtIngredients.Location = new System.Drawing.Point(125, 202);
            this.txtIngredients.Multiline = true;
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.Size = new System.Drawing.Size(256, 54);
            this.txtIngredients.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteStep);
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnStepUp);
            this.groupBox1.Controls.Add(this.btnNewStep);
            this.groupBox1.Controls.Add(this.lbSteps);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Controls.Add(this.txtNumServes);
            this.groupBox1.Controls.Add(this.lblNumServes);
            this.groupBox1.Controls.Add(this.chkbox_fav);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIngredients);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtMethods);
            this.groupBox1.Controls.Add(this.lblIngredients);
            this.groupBox1.Controls.Add(this.txtPrepTime);
            this.groupBox1.Controls.Add(this.lblPrepTime);
            this.groupBox1.Controls.Add(this.lblInstructions);
            this.groupBox1.Location = new System.Drawing.Point(22, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 437);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recipe";
            // 
            // btnDeleteStep
            // 
            this.btnDeleteStep.Location = new System.Drawing.Point(20, 369);
            this.btnDeleteStep.Name = "btnDeleteStep";
            this.btnDeleteStep.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteStep.TabIndex = 14;
            this.btnDeleteStep.Text = "Delete Step";
            this.btnDeleteStep.UseVisualStyleBackColor = true;
            this.btnDeleteStep.Click += new System.EventHandler(this.btnDeleteStep_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(69, 340);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 23);
            this.btnDown.TabIndex = 12;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnStepUp
            // 
            this.btnStepUp.Location = new System.Drawing.Point(20, 340);
            this.btnStepUp.Name = "btnStepUp";
            this.btnStepUp.Size = new System.Drawing.Size(39, 23);
            this.btnStepUp.TabIndex = 11;
            this.btnStepUp.Text = "Up";
            this.btnStepUp.UseVisualStyleBackColor = true;
            this.btnStepUp.Click += new System.EventHandler(this.btnStepUp_Click);
            // 
            // btnNewStep
            // 
            this.btnNewStep.Location = new System.Drawing.Point(20, 311);
            this.btnNewStep.Name = "btnNewStep";
            this.btnNewStep.Size = new System.Drawing.Size(75, 23);
            this.btnNewStep.TabIndex = 10;
            this.btnNewStep.Text = "Add Step";
            this.btnNewStep.UseVisualStyleBackColor = true;
            this.btnNewStep.Click += new System.EventHandler(this.btnNewStep_Click);
            // 
            // lbSteps
            // 
            this.lbSteps.DisplayMember = "Content";
            this.lbSteps.FormattingEnabled = true;
            this.lbSteps.Location = new System.Drawing.Point(125, 306);
            this.lbSteps.Name = "lbSteps";
            this.lbSteps.Size = new System.Drawing.Size(256, 95);
            this.lbSteps.TabIndex = 9;
            this.lbSteps.SelectedIndexChanged += new System.EventHandler(this.lbSteps_SelectedIndexChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.cbCategory.DisplayMember = "Name";
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(125, 121);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(256, 21);
            this.cbCategory.TabIndex = 8;
            // 
            // txtNumServes
            // 
            this.txtNumServes.Location = new System.Drawing.Point(125, 84);
            this.txtNumServes.Name = "txtNumServes";
            this.txtNumServes.Size = new System.Drawing.Size(256, 20);
            this.txtNumServes.TabIndex = 5;
            // 
            // lblNumServes
            // 
            this.lblNumServes.AutoSize = true;
            this.lblNumServes.Location = new System.Drawing.Point(30, 91);
            this.lblNumServes.Name = "lblNumServes";
            this.lblNumServes.Size = new System.Drawing.Size(40, 13);
            this.lblNumServes.TabIndex = 6;
            this.lblNumServes.Text = "Serves";
            // 
            // chkbox_fav
            // 
            this.chkbox_fav.AutoSize = true;
            this.chkbox_fav.Location = new System.Drawing.Point(311, 19);
            this.chkbox_fav.Name = "chkbox_fav";
            this.chkbox_fav.Size = new System.Drawing.Size(70, 17);
            this.chkbox_fav.TabIndex = 7;
            this.chkbox_fav.Text = "Favourite";
            this.chkbox_fav.UseVisualStyleBackColor = true;
            this.chkbox_fav.CheckedChanged += new System.EventHandler(this.chkbox_fav_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Category";
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cbFilter.DisplayMember = "Name";
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(565, 26);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(121, 21);
            this.cbFilter.TabIndex = 9;
            this.cbFilter.Text = "Filter";
            // 
            // lvFavourite
            // 
            this.lvFavourite.HideSelection = false;
            this.lvFavourite.Location = new System.Drawing.Point(986, 69);
            this.lvFavourite.Name = "lvFavourite";
            this.lvFavourite.Size = new System.Drawing.Size(207, 368);
            this.lvFavourite.TabIndex = 11;
            this.lvFavourite.UseCompatibleStateImageBehavior = false;
            this.lvFavourite.SelectedIndexChanged += new System.EventHandler(this.lvFavourite_SelectedIndexChanged);
            // 
            // lblFav
            // 
            this.lblFav.AutoSize = true;
            this.lblFav.Location = new System.Drawing.Point(1011, 47);
            this.lblFav.Name = "lblFav";
            this.lblFav.Size = new System.Drawing.Size(70, 13);
            this.lblFav.TabIndex = 12;
            this.lblFav.Text = "Favourite List";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 502);
            this.Controls.Add(this.lblFav);
            this.Controls.Add(this.lvFavourite);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtSearch);
            this.Name = "Form1";
            this.Text = "HSTS Recipe Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtPrepTime;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblIngredients;
        private System.Windows.Forms.Label lblPrepTime;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtMethods;
        private System.Windows.Forms.TextBox txtIngredients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumServes;
        private System.Windows.Forms.Label lblNumServes;
        private System.Windows.Forms.CheckBox chkbox_fav;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ListBox lbSteps;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnStepUp;
        private System.Windows.Forms.Button btnNewStep;
        private System.Windows.Forms.Button btnDeleteStep;
        private System.Windows.Forms.ListView lvFavourite;
        private System.Windows.Forms.Label lblFav;
    }
}

