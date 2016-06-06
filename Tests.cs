using System;
using System.Collections.Generic;
using Free.Core.Collections.Generic;
using NUnit.Framework;

namespace Free.Core.Tests
{
	[TestFixture]
	class Tests
	{
		static IEnumerable<int> GetEnumerator(int[] arr)
		{
			foreach(int i in arr) yield return i;
		}

		[Test]
		public static void LinkedHashSetTest()
		{
			int[] setEmpty = { };
			int[] set1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] set2 = { 1, 2, 3, 4, 5, 6, 6, 8, 9 };
			int[] set3 = { 1, 2, 3, 4, 5, 6, 8, 9, 0 };

			LinkedHashSet<int> lhsEmpty = new LinkedHashSet<int>();
			LinkedHashSet<int> lhs1 = new LinkedHashSet<int>(set1);
			LinkedHashSet<int> lhs2 = new LinkedHashSet<int>(set2);
			LinkedHashSet<int> lhs3 = new LinkedHashSet<int>(set3);

			HashSet<int> hsEmpty = new HashSet<int>();
			HashSet<int> hs1 = new HashSet<int>(set1);
			HashSet<int> hs2 = new HashSet<int>(set2);
			HashSet<int> hs3 = new HashSet<int>(set3);

			#region SetEquals
			Assert.IsTrue(lhsEmpty.SetEquals(lhsEmpty));
			Assert.IsTrue(lhs1.SetEquals(lhs1));
			Assert.IsTrue(lhs2.SetEquals(lhs2));
			Assert.IsTrue(lhs3.SetEquals(lhs3));

			Assert.IsTrue(lhsEmpty.SetEquals(hsEmpty));
			Assert.IsTrue(lhs1.SetEquals(hs1));
			Assert.IsTrue(lhs2.SetEquals(hs2));
			Assert.IsTrue(lhs3.SetEquals(hs3));

			Assert.IsTrue(lhsEmpty.SetEquals(setEmpty));
			Assert.IsTrue(lhs1.SetEquals(set1));
			Assert.IsTrue(lhs2.SetEquals(set2));
			Assert.IsTrue(lhs3.SetEquals(set3));

			Assert.IsTrue(lhsEmpty.SetEquals(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.SetEquals(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.SetEquals(GetEnumerator(set2)));
			Assert.IsTrue(lhs3.SetEquals(GetEnumerator(set3)));

			Assert.IsFalse(lhsEmpty.SetEquals(lhs1));
			Assert.IsFalse(lhsEmpty.SetEquals(lhs2));
			Assert.IsFalse(lhsEmpty.SetEquals(lhs3));
			Assert.IsFalse(lhsEmpty.SetEquals(hs1));
			Assert.IsFalse(lhsEmpty.SetEquals(hs2));
			Assert.IsFalse(lhsEmpty.SetEquals(hs3));
			Assert.IsFalse(lhsEmpty.SetEquals(set1));
			Assert.IsFalse(lhsEmpty.SetEquals(set2));
			Assert.IsFalse(lhsEmpty.SetEquals(set3));
			Assert.IsFalse(lhsEmpty.SetEquals(GetEnumerator(set1)));
			Assert.IsFalse(lhsEmpty.SetEquals(GetEnumerator(set2)));
			Assert.IsFalse(lhsEmpty.SetEquals(GetEnumerator(set3)));

			Assert.IsFalse(lhs1.SetEquals(lhsEmpty));
			Assert.IsFalse(lhs1.SetEquals(lhs2));
			Assert.IsFalse(lhs1.SetEquals(lhs3));
			Assert.IsFalse(lhs1.SetEquals(hsEmpty));
			Assert.IsFalse(lhs1.SetEquals(hs2));
			Assert.IsFalse(lhs1.SetEquals(hs3));
			Assert.IsFalse(lhs1.SetEquals(setEmpty));
			Assert.IsFalse(lhs1.SetEquals(set2));
			Assert.IsFalse(lhs1.SetEquals(set3));
			Assert.IsFalse(lhs1.SetEquals(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs1.SetEquals(GetEnumerator(set2)));
			Assert.IsFalse(lhs1.SetEquals(GetEnumerator(set3)));

			Assert.IsFalse(lhs2.SetEquals(lhsEmpty));
			Assert.IsFalse(lhs2.SetEquals(lhs1));
			Assert.IsFalse(lhs2.SetEquals(lhs3));
			Assert.IsFalse(lhs2.SetEquals(hsEmpty));
			Assert.IsFalse(lhs2.SetEquals(hs1));
			Assert.IsFalse(lhs2.SetEquals(hs3));
			Assert.IsFalse(lhs2.SetEquals(setEmpty));
			Assert.IsFalse(lhs2.SetEquals(set1));
			Assert.IsFalse(lhs2.SetEquals(set3));
			Assert.IsFalse(lhs2.SetEquals(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs2.SetEquals(GetEnumerator(set1)));
			Assert.IsFalse(lhs2.SetEquals(GetEnumerator(set3)));

			Assert.IsFalse(lhs3.SetEquals(lhsEmpty));
			Assert.IsFalse(lhs3.SetEquals(lhs1));
			Assert.IsFalse(lhs3.SetEquals(lhs2));
			Assert.IsFalse(lhs3.SetEquals(hsEmpty));
			Assert.IsFalse(lhs3.SetEquals(hs1));
			Assert.IsFalse(lhs3.SetEquals(hs2));
			Assert.IsFalse(lhs3.SetEquals(setEmpty));
			Assert.IsFalse(lhs3.SetEquals(set1));
			Assert.IsFalse(lhs3.SetEquals(set2));
			Assert.IsFalse(lhs3.SetEquals(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs3.SetEquals(GetEnumerator(set1)));
			Assert.IsFalse(lhs3.SetEquals(GetEnumerator(set2)));
			#endregion

			#region Overlaps
			Assert.IsFalse(lhsEmpty.Overlaps(lhsEmpty));
			Assert.IsTrue(lhs1.Overlaps(lhs1));
			Assert.IsTrue(lhs2.Overlaps(lhs2));
			Assert.IsTrue(lhs3.Overlaps(lhs3));

			Assert.IsFalse(lhsEmpty.Overlaps(hsEmpty));
			Assert.IsTrue(lhs1.Overlaps(hs1));
			Assert.IsTrue(lhs2.Overlaps(hs2));
			Assert.IsTrue(lhs3.Overlaps(hs3));

			Assert.IsFalse(lhsEmpty.Overlaps(setEmpty));
			Assert.IsTrue(lhs1.Overlaps(set1));
			Assert.IsTrue(lhs2.Overlaps(set2));
			Assert.IsTrue(lhs3.Overlaps(set3));

			Assert.IsFalse(lhsEmpty.Overlaps(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.Overlaps(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.Overlaps(GetEnumerator(set2)));
			Assert.IsTrue(lhs3.Overlaps(GetEnumerator(set3)));

			Assert.IsFalse(lhsEmpty.Overlaps(lhs1));
			Assert.IsFalse(lhsEmpty.Overlaps(lhs2));
			Assert.IsFalse(lhsEmpty.Overlaps(lhs3));
			Assert.IsFalse(lhsEmpty.Overlaps(hs1));
			Assert.IsFalse(lhsEmpty.Overlaps(hs2));
			Assert.IsFalse(lhsEmpty.Overlaps(hs3));
			Assert.IsFalse(lhsEmpty.Overlaps(set1));
			Assert.IsFalse(lhsEmpty.Overlaps(set2));
			Assert.IsFalse(lhsEmpty.Overlaps(set3));
			Assert.IsFalse(lhsEmpty.Overlaps(GetEnumerator(set1)));
			Assert.IsFalse(lhsEmpty.Overlaps(GetEnumerator(set2)));
			Assert.IsFalse(lhsEmpty.Overlaps(GetEnumerator(set3)));

			Assert.IsFalse(lhs1.Overlaps(lhsEmpty));
			Assert.IsTrue(lhs1.Overlaps(lhs2));
			Assert.IsTrue(lhs1.Overlaps(lhs3));
			Assert.IsFalse(lhs1.Overlaps(hsEmpty));
			Assert.IsTrue(lhs1.Overlaps(hs2));
			Assert.IsTrue(lhs1.Overlaps(hs3));
			Assert.IsFalse(lhs1.Overlaps(setEmpty));
			Assert.IsTrue(lhs1.Overlaps(set2));
			Assert.IsTrue(lhs1.Overlaps(set3));
			Assert.IsFalse(lhs1.Overlaps(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.Overlaps(GetEnumerator(set2)));
			Assert.IsTrue(lhs1.Overlaps(GetEnumerator(set3)));

			Assert.IsFalse(lhs2.Overlaps(lhsEmpty));
			Assert.IsTrue(lhs2.Overlaps(lhs1));
			Assert.IsTrue(lhs2.Overlaps(lhs3));
			Assert.IsFalse(lhs2.Overlaps(hsEmpty));
			Assert.IsTrue(lhs2.Overlaps(hs1));
			Assert.IsTrue(lhs2.Overlaps(hs3));
			Assert.IsFalse(lhs2.Overlaps(setEmpty));
			Assert.IsTrue(lhs2.Overlaps(set1));
			Assert.IsTrue(lhs2.Overlaps(set3));
			Assert.IsFalse(lhs2.Overlaps(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs2.Overlaps(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.Overlaps(GetEnumerator(set3)));

			Assert.IsFalse(lhs3.Overlaps(lhsEmpty));
			Assert.IsTrue(lhs3.Overlaps(lhs1));
			Assert.IsTrue(lhs3.Overlaps(lhs2));
			Assert.IsFalse(lhs3.Overlaps(hsEmpty));
			Assert.IsTrue(lhs3.Overlaps(hs1));
			Assert.IsTrue(lhs3.Overlaps(hs2));
			Assert.IsFalse(lhs3.Overlaps(setEmpty));
			Assert.IsTrue(lhs3.Overlaps(set1));
			Assert.IsTrue(lhs3.Overlaps(set2));
			Assert.IsFalse(lhs3.Overlaps(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs3.Overlaps(GetEnumerator(set1)));
			Assert.IsTrue(lhs3.Overlaps(GetEnumerator(set2)));
			#endregion

			#region IsSubsetOf
			Assert.IsTrue(lhsEmpty.IsSubsetOf(lhsEmpty));
			Assert.IsTrue(lhs1.IsSubsetOf(lhs1));
			Assert.IsTrue(lhs2.IsSubsetOf(lhs2));
			Assert.IsTrue(lhs3.IsSubsetOf(lhs3));

			Assert.IsTrue(lhsEmpty.IsSubsetOf(hsEmpty));
			Assert.IsTrue(lhs1.IsSubsetOf(hs1));
			Assert.IsTrue(lhs2.IsSubsetOf(hs2));
			Assert.IsTrue(lhs3.IsSubsetOf(hs3));

			Assert.IsTrue(lhsEmpty.IsSubsetOf(setEmpty));
			Assert.IsTrue(lhs1.IsSubsetOf(set1));
			Assert.IsTrue(lhs2.IsSubsetOf(set2));
			Assert.IsTrue(lhs3.IsSubsetOf(set3));

			Assert.IsTrue(lhsEmpty.IsSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.IsSubsetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.IsSubsetOf(GetEnumerator(set2)));
			Assert.IsTrue(lhs3.IsSubsetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhsEmpty.IsSubsetOf(lhs1));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(lhs2));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(lhs3));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(hs1));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(hs2));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(hs3));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(set1));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(set2));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(set3));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(GetEnumerator(set2)));
			Assert.IsTrue(lhsEmpty.IsSubsetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhs1.IsSubsetOf(lhsEmpty));
			Assert.IsFalse(lhs1.IsSubsetOf(lhs2));
			Assert.IsFalse(lhs1.IsSubsetOf(lhs3));
			Assert.IsFalse(lhs1.IsSubsetOf(hsEmpty));
			Assert.IsFalse(lhs1.IsSubsetOf(hs2));
			Assert.IsFalse(lhs1.IsSubsetOf(hs3));
			Assert.IsFalse(lhs1.IsSubsetOf(setEmpty));
			Assert.IsFalse(lhs1.IsSubsetOf(set2));
			Assert.IsFalse(lhs1.IsSubsetOf(set3));
			Assert.IsFalse(lhs1.IsSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs1.IsSubsetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhs1.IsSubsetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhs2.IsSubsetOf(lhsEmpty));
			Assert.IsTrue(lhs2.IsSubsetOf(lhs1));
			Assert.IsTrue(lhs2.IsSubsetOf(lhs3));
			Assert.IsFalse(lhs2.IsSubsetOf(hsEmpty));
			Assert.IsTrue(lhs2.IsSubsetOf(hs1));
			Assert.IsTrue(lhs2.IsSubsetOf(hs3));
			Assert.IsFalse(lhs2.IsSubsetOf(setEmpty));
			Assert.IsTrue(lhs2.IsSubsetOf(set1));
			Assert.IsTrue(lhs2.IsSubsetOf(set3));
			Assert.IsFalse(lhs2.IsSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs2.IsSubsetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.IsSubsetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhs3.IsSubsetOf(lhsEmpty));
			Assert.IsFalse(lhs3.IsSubsetOf(lhs1));
			Assert.IsFalse(lhs3.IsSubsetOf(lhs2));
			Assert.IsFalse(lhs3.IsSubsetOf(hsEmpty));
			Assert.IsFalse(lhs3.IsSubsetOf(hs1));
			Assert.IsFalse(lhs3.IsSubsetOf(hs2));
			Assert.IsFalse(lhs3.IsSubsetOf(setEmpty));
			Assert.IsFalse(lhs3.IsSubsetOf(set1));
			Assert.IsFalse(lhs3.IsSubsetOf(set2));
			Assert.IsFalse(lhs3.IsSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs3.IsSubsetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhs3.IsSubsetOf(GetEnumerator(set2)));
			#endregion

			#region IsProperSubsetOf
			Assert.IsFalse(lhsEmpty.IsProperSubsetOf(lhsEmpty));
			Assert.IsFalse(lhs1.IsProperSubsetOf(lhs1));
			Assert.IsFalse(lhs2.IsProperSubsetOf(lhs2));
			Assert.IsFalse(lhs3.IsProperSubsetOf(lhs3));

			Assert.IsFalse(lhsEmpty.IsProperSubsetOf(hsEmpty));
			Assert.IsFalse(lhs1.IsProperSubsetOf(hs1));
			Assert.IsFalse(lhs2.IsProperSubsetOf(hs2));
			Assert.IsFalse(lhs3.IsProperSubsetOf(hs3));

			Assert.IsFalse(lhsEmpty.IsProperSubsetOf(setEmpty));
			Assert.IsFalse(lhs1.IsProperSubsetOf(set1));
			Assert.IsFalse(lhs2.IsProperSubsetOf(set2));
			Assert.IsFalse(lhs3.IsProperSubsetOf(set3));

			Assert.IsFalse(lhsEmpty.IsProperSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs1.IsProperSubsetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhs2.IsProperSubsetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhs3.IsProperSubsetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(lhs1));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(lhs2));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(lhs3));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(hs1));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(hs2));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(hs3));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(set1));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(set2));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(set3));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(GetEnumerator(set2)));
			Assert.IsTrue(lhsEmpty.IsProperSubsetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhs1.IsProperSubsetOf(lhsEmpty));
			Assert.IsFalse(lhs1.IsProperSubsetOf(lhs2));
			Assert.IsFalse(lhs1.IsProperSubsetOf(lhs3));
			Assert.IsFalse(lhs1.IsProperSubsetOf(hsEmpty));
			Assert.IsFalse(lhs1.IsProperSubsetOf(hs2));
			Assert.IsFalse(lhs1.IsProperSubsetOf(hs3));
			Assert.IsFalse(lhs1.IsProperSubsetOf(setEmpty));
			Assert.IsFalse(lhs1.IsProperSubsetOf(set2));
			Assert.IsFalse(lhs1.IsProperSubsetOf(set3));
			Assert.IsFalse(lhs1.IsProperSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs1.IsProperSubsetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhs1.IsProperSubsetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhs2.IsProperSubsetOf(lhsEmpty));
			Assert.IsTrue(lhs2.IsProperSubsetOf(lhs1));
			Assert.IsTrue(lhs2.IsProperSubsetOf(lhs3));
			Assert.IsFalse(lhs2.IsProperSubsetOf(hsEmpty));
			Assert.IsTrue(lhs2.IsProperSubsetOf(hs1));
			Assert.IsTrue(lhs2.IsProperSubsetOf(hs3));
			Assert.IsFalse(lhs2.IsProperSubsetOf(setEmpty));
			Assert.IsTrue(lhs2.IsProperSubsetOf(set1));
			Assert.IsTrue(lhs2.IsProperSubsetOf(set3));
			Assert.IsFalse(lhs2.IsProperSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs2.IsProperSubsetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.IsProperSubsetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhs3.IsProperSubsetOf(lhsEmpty));
			Assert.IsFalse(lhs3.IsProperSubsetOf(lhs1));
			Assert.IsFalse(lhs3.IsProperSubsetOf(lhs2));
			Assert.IsFalse(lhs3.IsProperSubsetOf(hsEmpty));
			Assert.IsFalse(lhs3.IsProperSubsetOf(hs1));
			Assert.IsFalse(lhs3.IsProperSubsetOf(hs2));
			Assert.IsFalse(lhs3.IsProperSubsetOf(setEmpty));
			Assert.IsFalse(lhs3.IsProperSubsetOf(set1));
			Assert.IsFalse(lhs3.IsProperSubsetOf(set2));
			Assert.IsFalse(lhs3.IsProperSubsetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs3.IsProperSubsetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhs3.IsProperSubsetOf(GetEnumerator(set2)));
			#endregion

			#region IsSupersetOf
			Assert.IsTrue(lhsEmpty.IsSupersetOf(lhsEmpty));
			Assert.IsTrue(lhs1.IsSupersetOf(lhs1));
			Assert.IsTrue(lhs2.IsSupersetOf(lhs2));
			Assert.IsTrue(lhs3.IsSupersetOf(lhs3));

			Assert.IsTrue(lhsEmpty.IsSupersetOf(hsEmpty));
			Assert.IsTrue(lhs1.IsSupersetOf(hs1));
			Assert.IsTrue(lhs2.IsSupersetOf(hs2));
			Assert.IsTrue(lhs3.IsSupersetOf(hs3));

			Assert.IsTrue(lhsEmpty.IsSupersetOf(setEmpty));
			Assert.IsTrue(lhs1.IsSupersetOf(set1));
			Assert.IsTrue(lhs2.IsSupersetOf(set2));
			Assert.IsTrue(lhs3.IsSupersetOf(set3));

			Assert.IsTrue(lhsEmpty.IsSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.IsSupersetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhs2.IsSupersetOf(GetEnumerator(set2)));
			Assert.IsTrue(lhs3.IsSupersetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhsEmpty.IsSupersetOf(lhs1));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(lhs2));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(lhs3));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(hs1));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(hs2));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(hs3));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(set1));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(set2));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(set3));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhsEmpty.IsSupersetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhs1.IsSupersetOf(lhsEmpty));
			Assert.IsTrue(lhs1.IsSupersetOf(lhs2));
			Assert.IsFalse(lhs1.IsSupersetOf(lhs3));
			Assert.IsTrue(lhs1.IsSupersetOf(hsEmpty));
			Assert.IsTrue(lhs1.IsSupersetOf(hs2));
			Assert.IsFalse(lhs1.IsSupersetOf(hs3));
			Assert.IsTrue(lhs1.IsSupersetOf(setEmpty));
			Assert.IsTrue(lhs1.IsSupersetOf(set2));
			Assert.IsFalse(lhs1.IsSupersetOf(set3));
			Assert.IsTrue(lhs1.IsSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.IsSupersetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhs1.IsSupersetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhs2.IsSupersetOf(lhsEmpty));
			Assert.IsFalse(lhs2.IsSupersetOf(lhs1));
			Assert.IsFalse(lhs2.IsSupersetOf(lhs3));
			Assert.IsTrue(lhs2.IsSupersetOf(hsEmpty));
			Assert.IsFalse(lhs2.IsSupersetOf(hs1));
			Assert.IsFalse(lhs2.IsSupersetOf(hs3));
			Assert.IsTrue(lhs2.IsSupersetOf(setEmpty));
			Assert.IsFalse(lhs2.IsSupersetOf(set1));
			Assert.IsFalse(lhs2.IsSupersetOf(set3));
			Assert.IsTrue(lhs2.IsSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs2.IsSupersetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhs2.IsSupersetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhs3.IsSupersetOf(lhsEmpty));
			Assert.IsFalse(lhs3.IsSupersetOf(lhs1));
			Assert.IsTrue(lhs3.IsSupersetOf(lhs2));
			Assert.IsTrue(lhs3.IsSupersetOf(hsEmpty));
			Assert.IsFalse(lhs3.IsSupersetOf(hs1));
			Assert.IsTrue(lhs3.IsSupersetOf(hs2));
			Assert.IsTrue(lhs3.IsSupersetOf(setEmpty));
			Assert.IsFalse(lhs3.IsSupersetOf(set1));
			Assert.IsTrue(lhs3.IsSupersetOf(set2));
			Assert.IsTrue(lhs3.IsSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs3.IsSupersetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhs3.IsSupersetOf(GetEnumerator(set2)));
			#endregion

			#region IsProperSupersetOf
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(lhsEmpty));
			Assert.IsFalse(lhs1.IsProperSupersetOf(lhs1));
			Assert.IsFalse(lhs2.IsProperSupersetOf(lhs2));
			Assert.IsFalse(lhs3.IsProperSupersetOf(lhs3));

			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(hsEmpty));
			Assert.IsFalse(lhs1.IsProperSupersetOf(hs1));
			Assert.IsFalse(lhs2.IsProperSupersetOf(hs2));
			Assert.IsFalse(lhs3.IsProperSupersetOf(hs3));

			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(setEmpty));
			Assert.IsFalse(lhs1.IsProperSupersetOf(set1));
			Assert.IsFalse(lhs2.IsProperSupersetOf(set2));
			Assert.IsFalse(lhs3.IsProperSupersetOf(set3));

			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs1.IsProperSupersetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhs2.IsProperSupersetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhs3.IsProperSupersetOf(GetEnumerator(set3)));

			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(lhs1));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(lhs2));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(lhs3));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(hs1));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(hs2));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(hs3));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(set1));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(set2));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(set3));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhsEmpty.IsProperSupersetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhs1.IsProperSupersetOf(lhsEmpty));
			Assert.IsTrue(lhs1.IsProperSupersetOf(lhs2));
			Assert.IsFalse(lhs1.IsProperSupersetOf(lhs3));
			Assert.IsTrue(lhs1.IsProperSupersetOf(hsEmpty));
			Assert.IsTrue(lhs1.IsProperSupersetOf(hs2));
			Assert.IsFalse(lhs1.IsProperSupersetOf(hs3));
			Assert.IsTrue(lhs1.IsProperSupersetOf(setEmpty));
			Assert.IsTrue(lhs1.IsProperSupersetOf(set2));
			Assert.IsFalse(lhs1.IsProperSupersetOf(set3));
			Assert.IsTrue(lhs1.IsProperSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsTrue(lhs1.IsProperSupersetOf(GetEnumerator(set2)));
			Assert.IsFalse(lhs1.IsProperSupersetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhs2.IsProperSupersetOf(lhsEmpty));
			Assert.IsFalse(lhs2.IsProperSupersetOf(lhs1));
			Assert.IsFalse(lhs2.IsProperSupersetOf(lhs3));
			Assert.IsTrue(lhs2.IsProperSupersetOf(hsEmpty));
			Assert.IsFalse(lhs2.IsProperSupersetOf(hs1));
			Assert.IsFalse(lhs2.IsProperSupersetOf(hs3));
			Assert.IsTrue(lhs2.IsProperSupersetOf(setEmpty));
			Assert.IsFalse(lhs2.IsProperSupersetOf(set1));
			Assert.IsFalse(lhs2.IsProperSupersetOf(set3));
			Assert.IsTrue(lhs2.IsProperSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs2.IsProperSupersetOf(GetEnumerator(set1)));
			Assert.IsFalse(lhs2.IsProperSupersetOf(GetEnumerator(set3)));

			Assert.IsTrue(lhs3.IsProperSupersetOf(lhsEmpty));
			Assert.IsFalse(lhs3.IsProperSupersetOf(lhs1));
			Assert.IsTrue(lhs3.IsProperSupersetOf(lhs2));
			Assert.IsTrue(lhs3.IsProperSupersetOf(hsEmpty));
			Assert.IsFalse(lhs3.IsProperSupersetOf(hs1));
			Assert.IsTrue(lhs3.IsProperSupersetOf(hs2));
			Assert.IsTrue(lhs3.IsProperSupersetOf(setEmpty));
			Assert.IsFalse(lhs3.IsProperSupersetOf(set1));
			Assert.IsTrue(lhs3.IsProperSupersetOf(set2));
			Assert.IsTrue(lhs3.IsProperSupersetOf(GetEnumerator(setEmpty)));
			Assert.IsFalse(lhs3.IsProperSupersetOf(GetEnumerator(set1)));
			Assert.IsTrue(lhs3.IsProperSupersetOf(GetEnumerator(set2)));
			#endregion

			#region Remove, Add and Contains
			Assert.IsTrue(lhs1.Remove(7));
			Assert.AreEqual(lhs1.Count, 8);
			Assert.IsTrue(lhs1.SetEquals(lhs2));
			Assert.IsFalse(lhs1.Remove(7));
			Assert.AreEqual(lhs1.Count, 8);

			Assert.IsTrue(lhs1.Add(0));
			Assert.AreEqual(lhs1.Count, 9);
			Assert.IsTrue(lhs1.SetEquals(lhs3));
			Assert.IsFalse(lhs1.Add(0));
			Assert.AreEqual(lhs1.Count, 9);

			Assert.IsTrue(lhs1.Contains(3));
			Assert.IsTrue(lhs1.Contains(0));

			Assert.IsFalse(lhs1.Contains(7));
			Assert.IsFalse(lhs3.Contains(7));

			lhs1.Clear();
			Assert.AreEqual(lhs1.Count, 0);
			Assert.IsTrue(lhs1.SetEquals(lhsEmpty));
			#endregion

			#region ExceptWith
			lhs1 = new LinkedHashSet<int>(set1);
			lhs2 = new LinkedHashSet<int>(set2);
			lhs3 = new LinkedHashSet<int>(set3);

			lhs1.ExceptWith(lhs2);
			Assert.AreEqual(lhs1.Count, 1);
			Assert.IsTrue(lhs1.Contains(7));

			lhs2.ExceptWith(lhs1);
			Assert.IsTrue(lhs2.SetEquals(set2));

			lhs1.ExceptWith(lhs3);
			Assert.AreEqual(lhs1.Count, 1);
			Assert.IsTrue(lhs1.Contains(7));

			lhs3.ExceptWith(lhs2);
			Assert.AreEqual(lhs3.Count, 1);
			Assert.IsTrue(lhs3.Contains(0));
			#endregion

			#region UnionWith
			lhs1 = new LinkedHashSet<int>(set1);
			lhs2 = new LinkedHashSet<int>(set2);
			lhs3 = new LinkedHashSet<int>(set3);

			lhs1.UnionWith(lhs2);
			Assert.IsTrue(lhs1.SetEquals(set1));

			lhs3.UnionWith(lhs2);
			Assert.IsTrue(lhs3.SetEquals(set3));

			lhs3.UnionWith(lhs1);
			Assert.IsTrue(lhs3.Contains(7));
			Assert.IsTrue(lhs3.Contains(0));
			Assert.AreEqual(lhs3.Count, 10);
			#endregion

			#region IntersectWith
			lhs1 = new LinkedHashSet<int>(set1);
			lhs2 = new LinkedHashSet<int>(set2);
			lhs3 = new LinkedHashSet<int>(set3);

			lhs1.IntersectWith(lhs2);
			Assert.IsTrue(lhs1.SetEquals(set2));

			lhs3.IntersectWith(lhs2);
			Assert.IsTrue(lhs3.SetEquals(set2));

			lhs1 = new LinkedHashSet<int>(set1);
			lhs2 = new LinkedHashSet<int>(set2);
			lhs3 = new LinkedHashSet<int>(set3);

			lhs3.IntersectWith(lhs1);
			Assert.IsFalse(lhs3.Contains(7));
			Assert.IsFalse(lhs3.Contains(0));
			Assert.AreEqual(lhs3.Count, 8);
			Assert.IsTrue(lhs3.SetEquals(set2));
			#endregion

			#region SymmetricExceptWith
			lhs1 = new LinkedHashSet<int>(set1);
			lhs2 = new LinkedHashSet<int>(set2);
			lhs3 = new LinkedHashSet<int>(set3);

			lhs1.SymmetricExceptWith(lhs3);
			Assert.AreEqual(lhs1.Count, 2);
			Assert.IsTrue(lhs1.Contains(0));
			Assert.IsTrue(lhs1.Contains(7));

			lhs1.SymmetricExceptWith(lhs2);
			Assert.AreEqual(lhs1.Count, 10);
			#endregion

			LinkedHashSet<int> lhs = new LinkedHashSet<int>();

			for (int i=0; i<set1.Length; i++) lhs.Add(set1[i]);

			List<int> set1a = new List<int>();
			foreach (var i in lhs) set1a.Add(i);
			for (int i = 0; i < set1.Length; i++) Assert.AreEqual(set1[i], set1a[i]);

			lhs.Remove(7);
			lhs.Add(0);

			set1a.Clear();
			foreach (var i in lhs) set1a.Add(i);
			for (int i = 0; i < set3.Length; i++) Assert.AreEqual(set3[i], set1a[i]);
		}

		[Test]
		public static void LinkedDictionaryTest()
		{
			LinkedDictionary<string, int> a = new LinkedDictionary<string, int>();

			a.Add("a1", 1);
			a.Add("a12", 12);
			a.Add("a123", 123);
			a.Add("a4", 4);
			a.Add("a5", 5);

			Assert.AreEqual(5, a.Count);

			Assert.IsTrue(a.ContainsKey("a4"));
			Assert.IsTrue(a.ContainsKey("a123"));

			Assert.IsTrue(a.Remove("a123"));
			Assert.IsFalse(a.Remove("a123"));
			Assert.IsFalse(a.ContainsKey("a123"));

			Assert.AreEqual(4, a.Count);

			List<string> keys = new List<string>(a.Keys);
			List<int> values = new List<int>(a.Values);
			List<KeyValuePair<string, int>> kv = new List<KeyValuePair<string, int>>(a);

			Assert.AreEqual("a1", keys[0]);
			Assert.AreEqual("a12", keys[1]);
			Assert.AreEqual("a4", keys[2]);
			Assert.AreEqual("a5", keys[3]);

			Assert.AreEqual(1, values[0]);
			Assert.AreEqual(12, values[1]);
			Assert.AreEqual(4, values[2]);
			Assert.AreEqual(5, values[3]);

			Assert.AreEqual("a1", kv[0].Key);
			Assert.AreEqual("a12", kv[1].Key);
			Assert.AreEqual("a4", kv[2].Key);
			Assert.AreEqual("a5", kv[3].Key);

			Assert.AreEqual(1, kv[0].Value);
			Assert.AreEqual(12, kv[1].Value);
			Assert.AreEqual(4, kv[2].Value);
			Assert.AreEqual(5, kv[3].Value);

			a.Clear();
			Assert.AreEqual(0, a.Count);
		}

		[Test]
		public static void PriorityQueueTest()
		{
			PriorityQueue<int> queue = new PriorityQueue<int>();

			queue.Add(43);
			queue.Add(3);
			queue.Add(4);
			queue.Add(98);
			queue.Add(32);
			queue.Add(-28);
			queue.Add(17);

			Assert.AreEqual(7, queue.Count);

			Assert.AreEqual(-28, queue.Top);
			Assert.AreEqual(-28, queue.Pop());
			Assert.AreEqual(6, queue.Count);

			Assert.AreEqual(3, queue.Top);
			Assert.AreEqual(3, queue.Pop());
			Assert.AreEqual(5, queue.Count);

			Assert.AreEqual(4, queue.Pop());
			Assert.AreEqual(17, queue.Pop());
			Assert.AreEqual(32, queue.Pop());
			Assert.AreEqual(43, queue.Pop());
			Assert.AreEqual(1, queue.Count);

			Assert.AreEqual(98, queue.Top);
			Assert.AreEqual(98, queue.Pop());
			Assert.AreEqual(0, queue.Count);

			Assert.AreEqual(default(int), queue.Top);
			Assert.AreEqual(default(int), queue.Pop());
			Assert.AreEqual(default(int), queue.Top);
			Assert.AreEqual(default(int), queue.Pop());

			Random rnd = new Random();

			for (int i = 0; i < 2000; i++)
			{
				queue.Add(rnd.Next());
			}

			Assert.AreEqual(2000, queue.Count);

			int lastMin = int.MinValue;
			while (queue.Count > 0)
			{
				int cur = queue.Pop();
				Assert.LessOrEqual(lastMin, cur);
				lastMin = cur;
			}
		}
	}
}
