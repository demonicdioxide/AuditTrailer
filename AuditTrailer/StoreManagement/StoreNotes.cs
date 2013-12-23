/*
 * Created by SharpDevelop.
 * User: Arran
 * Date: 23/12/2013
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using AuditTrailer.Forms;
using AuditTrailer.Application.Model;
namespace AuditTrailer.StoreManagement
{
	/// <summary>
	/// Description of StoreNotes.
	/// </summary>
	public partial class StoreNotes : AuthorisedBaseForm
	{
		private Store _store;
		public StoreNotes(User user, Store store) : base(user)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_store = store;
		}
		
		protected override void LoadForm()
		{
			InitializeComponent();
		}
		
		void StoreNotesLoad(object sender, EventArgs e)
		{
			notesTextBox.Text = _store.Notes;
			packagingRatingTextBox.Text = _store.IsOnlineStore ? _store.PackagingRating.ToString() : "0";
		}
	}
}
