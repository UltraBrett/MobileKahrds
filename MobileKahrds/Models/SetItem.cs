﻿using System;
using SQLite.Net.Attributes;

namespace MobileKahrds
{
	public class SetItem
	{
		public SetItem ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
		public string Set { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
	}
}
