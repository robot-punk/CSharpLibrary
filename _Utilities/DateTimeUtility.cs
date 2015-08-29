﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>DateTime のユーティリティクラス。
    /// </summary>
    public static class DateTimeUtility
    {
        /// <summary>日付を表す文字列(yyyyMMdd)をDateTime型に変換する。失敗した場合はエラーをスローする。
        /// </summary>
        /// <param name="yyyymmdd">日付を表す文字列(yyyyMMdd)。</param>
        /// <returns>変換された日付。</returns>
        public static DateTime ParseYYYYMMDD(string yyyymmdd)
        {
            try
            {
                int year  = int.Parse(yyyymmdd.Substring(0, 4));
                int month = int.Parse(yyyymmdd.Substring(4, 2));
                int day   = int.Parse(yyyymmdd.Substring(6, 2));
                return new DateTime(year, month, day);
            }
            catch (Exception)
            {
                throw new Exception("日付の変換が失敗しました。");
            }
        }

        /// <summary>指定した日付の直近の日曜日を取得する。日曜日を指定した場合はその日付が返る。
        /// </summary>
        /// <param name="date">任意の日付。</param>
        /// <returns>指定した日付を含む週の金曜日の日付。</returns>
        public static DateTime GetSunday(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday: return date.Date.AddDays(0);
                case DayOfWeek.Monday: return date.Date.AddDays(6);
                case DayOfWeek.Tuesday: return date.Date.AddDays(5);
                case DayOfWeek.Wednesday: return date.Date.AddDays(4);
                case DayOfWeek.Thursday: return date.Date.AddDays(3);
                case DayOfWeek.Friday: return date.Date.AddDays(2);
                case DayOfWeek.Saturday: return date.Date.AddDays(1);
                default: return default(DateTime);
            }
        }

        /// <summary>指定した開始日と終了日の間の日付を列挙する。
        /// </summary>
        /// <param name="startDate">列挙する日付の開始日。</param>
        /// <param name="finishDate">列挙する日付の終了日。</param>
        /// <returns>指定した期間内の日付の列挙可能なコレクション。</returns>
        public static IEnumerable<DateTime> EnumerateDates(DateTime startDate, DateTime finishDate)
        {
            for (DateTime i = startDate.Date; i <= finishDate.Date; i = i.AddDays(1))
            {
                yield return i;
            }
        }

        /// <summary>開始日から指定した日数の日付を列挙する。
        /// </summary>
        /// <param name="startDate">列挙する日付の開始日。</param>
        /// <param name="days">列挙する日数。</param>
        /// <returns>日付の列挙可能なコレクション。</returns>
        public static IEnumerable<DateTime> EnumerateDates(DateTime startDate, int days)
        {
            foreach (int i in Enumerable.Range(0, days))
            {
                yield return startDate.AddDays(i);
            }
        }
    }
}
