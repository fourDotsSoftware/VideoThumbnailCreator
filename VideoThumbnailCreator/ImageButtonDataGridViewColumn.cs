using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace VideoThumbnailCreator
{
    
    public class ImageButtonColumn : DataGridViewColumn
    {
        public ImageButtonColumn()
            : base(new ImageButtonCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a ImageButtonCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(ImageButtonCell)))
                {
                    throw new InvalidCastException("Must be a ImageButtonCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class ImageButtonCell : DataGridViewImageCell
    {

        public ImageButtonCell()
            : base()
        {
            // Use the short date format.
            //this.Style.Format = "d";
            //this.Style.Format = Module.DateFormat;
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            ImageButtonEditingControl ctl =
                DataGridView.EditingControl as ImageButtonEditingControl;
            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                //ctl.Value = (Image)this.DefaultNewRowValue;
                ctl.Value = (Image)(new Bitmap(1, 1));
            }
            else
            {
                ctl.Value = (DateTime)this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that ImageButtonCell uses.
                return typeof(ImageButtonEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that ImageButtonCell contains.

                return typeof(Image);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DateTime.Now;
            }
        }
    }

    class ImageButtonEditingControl : Image, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;
        Image Img = null;

        public ImageButtonEditingControl()
        {
            //this.Format = DateTimePickerFormat.Short;
            return null;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        
        public object EditingControlFormattedValue
        {
            get
            {
                //return this.Value.ToShortDateString();
                return this.Img;
            }
            set
            {
                if (value is Image)
                {
                    this.Img = (Image)value;
                    
                }                
            }
        }
        
        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            
            
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                //return base.Cursor;
                return System.Windows.Forms.Cursors.Arrow;
            }
        }
        /*
        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }*/
    }

}
