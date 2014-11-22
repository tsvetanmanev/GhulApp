﻿using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhulApp.Models
{
    [ParseClassName("Event")]
    public class EventModel : ParseObject
    {
        public EventModel()
        {
            this.Participants = new List<ParseUser>();
        }

        [ParseFieldName("title")]
        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("description")]
        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("creator")]
        public ParseUser Creator
        {
            get { return GetProperty<ParseUser>(); }
            set { SetProperty<ParseUser>(value); }
        }

        [ParseFieldName("category")]
        public CategoryModel Category
        {
            get { return GetProperty<CategoryModel>(); }
            set { SetProperty<CategoryModel>(value); }
        }

        [ParseFieldName("EventDate")]
        public DateTime EventDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty<DateTime>(value); }
        }

        [ParseFieldName("participants")]
        public IEnumerable<ParseUser> Participants
        {
            get { return GetProperty<IEnumerable<ParseUser>>(); }
            set { SetProperty<IEnumerable<ParseUser>>(value); }
        }

    }
}
