using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name, bool isWeighted) : base(name,isWeighted)
		{
			Type = GradeBookType.Ranked;
		}

		public override char GetLetterGrade(double averageGrade)
		{
			if (Students.Count < 5)
			{
				throw new InvalidOperationException();
			}

			int scttc = (int)Math.Ceiling(Students.Count* 0.2);
			var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

			if(averageGrade >= grades[scttc - 1])
			{
				return 'A';
			}
			else if (averageGrade >= grades[(scttc * 2) - 1])
			{
				return 'B';
			}
			else if (averageGrade >= grades[(scttc * 3) - 1])
			{
				return 'C';
			}
			else if (averageGrade >= grades[(scttc * 4) - 1])
			{
				return 'D';
			}
			else
			{
				return 'F';
			}
		}

		public override void CalculateStatistics()
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students.");
			}
			else
			{
				base.CalculateStatistics();
			}
		}
		public override void CalculateStudentStatistics(string name)
		{
			if(Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students.");
			}
			else
			{
				base.CalculateStudentStatistics(name);
			}
		}






	}
}
