namespace xrefBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Download downloadForm = new();
            downloadForm.ShowDialog();

            if (downloadForm.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("You cancelled");
                Close();
            }

            else
            {
                // Prep Data
                DataContext = new ViewModel.MainForm(downloadForm.Xref);
            }
        }

        private void Form1_DataContextChanged(object sender, EventArgs e)
        {
            mainFormBindingSource.DataSource = DataContext;
        }
    }
}
