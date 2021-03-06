﻿using System;
using System.Collections.Generic;

namespace Dark_Basic_App_Parser {
	public class Helper {
		public static string GetStringBetween(string source, string start, string end) {
			try {
				int startPos = source.IndexOf(start, StringComparison.Ordinal) + start.Length;
				int endPos = source.IndexOf(end, startPos, StringComparison.Ordinal);
				if(endPos == -1) { return null; }
				return source.Substring(startPos, endPos - startPos);
			} catch(Exception) {
				return null;
			}
		}

		public static void AddMethodUsageLine(ref List<FunctionOrSubroutine> subroutinesAndFunctions, string lineContent, int curLine ) {
			//Calling function
			var index = subroutinesAndFunctions.FindIndex(f => lineContent.Contains(f.Name) && !lineContent.Contains("function"));
			//We found a valid function call
			if(index != -1) {
				subroutinesAndFunctions[index].LinesUsedOn.Add(curLine);
			}
		}

		public enum VariableType {
			String,
			Array_of_Strings,
			Int,
			Array_of_Ints,
			Float,
			Array_of_Floats,
			Unknown
		}

		public enum ConstructType {
			Function,
			Subroutine,
			Array
		}

		public enum Scope {
			Local,
			Global
		}

		public class Variable {
			public string Name { get; set; }
			public Scope Scope { get; set; }
			public VariableType TypeOfData { get; set; }
			//public object Value { get; set; }
			public int LineDeclaredAt { get; set; }
			public List<int> LinesUsedOn { get; set; }
			public string File { get; set; }
		}

		public class FunctionOrSubroutine {
			public string Name { get; set; }
			public ConstructType TypeOfConstruct { get; set; }
			public List<string> Parameters { get; set; }
			public string ReturnValue { get; set; }

			/// <summary>
			/// 0 is the start, 1 is the end.
			/// </summary>
			public List<int> LineDeclaredAt { get; set; }
			public List<int> LinesUsedOn { get; set; }
			public string File { get; set; }
		}

		/*
		public static bool IsVariable(List<string> nonVariableWords, List<string> removableVariableWords, string varName) {
			varName = RemoveNonVariableWords(removableVariableWords, varName);

			foreach(var variable in nonVariableWords) {
				if(varName.Contains(variable)) {
					return false;
				}
			}

			return true;
		}
		*/
	}
}
