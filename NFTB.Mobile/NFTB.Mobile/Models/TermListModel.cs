﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class TermListModel : BaseModel
    {
        public ObservableCollection<TermSummary> _TermList { get; set; }
        public ObservableCollection<TermSummary> TermList { get; set; } = new ObservableCollection<TermSummary>();

        public ObservableCollection<string> _TestList { get; set; }
        public ObservableCollection<string> TestList { get; set; } = new ObservableCollection<string>();

        private bool _IsBusy { get; set; }

        public bool IsBusy
        {
            get { return this._IsBusy; }
            set
            {
                if (this._IsBusy == value) return;
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        public TermSummary _SelectedTerm { get; set; }
        public TermSummary SelectedTerm
        {
            get { return this._SelectedTerm; }
            set
            {
                this._SelectedTerm = value;
                if (this._SelectedTerm != null) this.EditTerm();
            }
        }

        public ICommand OnEditTerm
        {
            get { return new Command(async () => await this.EditTerm()); }
        }

        public ICommand OnDeleteTerm
        {
            get { return new Command(async () => await this.DeleteTerm()); }
        }

        public ICommand OnGetTerms
        {
            get { return new Command(async () => await this.GetTerms()); }
        }

        public TermListModel(ContentPage ui) : base(ui)
        {
            this.GetTerms();
            this.TestList.Add("Test1");
            this.TestList.Add("Test2");
            this.TestList.Add("Test3");
        }

        public async Task GetTerms()
        {
            this.TermList.Clear();
            var termMgr = new TermManager();
            var termList = await termMgr.GetTerms(null);
            foreach (var term in termList)
            {
                var termStartStr = String.Format("{0:MMMM d yyyy}", term.TermStart);
                var termEndStr = term.TermEnd.HasValue ? String.Format("{0:MMMM d yyyy}", term.TermStart) : "???";
                term.TermRange = String.Format("{0} - {1}", termStartStr, termEndStr);
                this.TermList.Add(term);
            }
            this.IsBusy = false;
        }

        public async Task EditTerm()
        {
            var termEditorPage = new TermEditor(this.SelectedTerm);
            
            await this.UI.Navigation.PushAsync(termEditorPage);
        }



        public async Task DeleteTerm()
        {
            await this.UI.DisplayAlert("Confirm", "This will delete the selected term", "Ok", "Cancel");
            var termMgr = new TermManager();
            await termMgr.DeleteTerm(this.SelectedTerm.TermID);
        }

        


    }
}
