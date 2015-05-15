using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AaruthraEduEvolvConstants
{
    public class Video
    {

        public class Course
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
            public string Thumbnail { get; set; }
            public int SortOrder { get; set; }
            public decimal Fees { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }
            public List<Material> Materials { get; set; }

            public List<Course> ToVideo(DataTable videoDataTable)
            {
                var lsCourses = new List<Course>();
                foreach (DataRow row in videoDataTable.Rows)
                {
                    try
                    {
                        var cs = new Course
                        {
                            CourseId = Convert.ToInt16(row["CourseID"].ToString()),
                            CourseName = Convert.ToString(row["CourseName"].ToString()),
                            Description = Convert.ToString(row["Description"].ToString()),
                            Author = Convert.ToString(row["Author"].ToString()),
                            Thumbnail = Convert.ToString(row["Thumbnail"].ToString()),
                            SortOrder = Convert.ToInt16(row["SortOrder"].Equals(DBNull.Value) ? "0" : row["SortOrder"].ToString()),
                            Fees = Convert.ToDecimal(row["Fees"].ToString()),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"].Equals(DBNull.Value)
                                      ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                      : row["CreatedDate"].ToString()),
                            ModifiedDate = Convert.ToDateTime(row["ModifiedDate"].Equals(DBNull.Value)
                                    ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                    : row["ModifiedDate"].ToString()),
                        };
                        lsCourses.Add(cs);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                return lsCourses;
            }
        }


        public class Material
        {
            public int MaterialID { get; set; }
            public int CourseID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Length { get; set; }
            public int StatusID { get; set; }
            public string VideoURL { get; set; }
            public string Thumbnail { get; set; }
            public int SortOrder { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime ModifiedDate { get; set; }

            public List<Material> ToVideo(DataTable materialDataTable)
            {
                var lsMateraial = new List<Material>();
                foreach (DataRow row in materialDataTable.Rows)
                {
                    try
                    {
                        int sortorder = 0;
                        var cs = new Material
                        {
                            StatusID =
                                Convert.ToInt16(row["StatusID"].Equals(DBNull.Value) ? "0" : row["StatusID"].ToString()),
                            CourseID = Convert.ToInt16(row["CourseID"].ToString()),
                            Title = Convert.ToString(row["Title"].ToString()),
                            Description = Convert.ToString(row["Description"].ToString()),
                            Length = Convert.ToString(row["Length"].ToString()),
                            VideoURL = Convert.ToString(row["VideoURL"].ToString()),
                            Thumbnail = Convert.ToString(row["Thumbnail"].ToString()),
                            SortOrder =
                                Convert.ToInt16(row["SortOrder"].Equals(DBNull.Value)
                                    ? "0"
                                    : row["SortOrder"].ToString()),
                            CreatedDate = Convert.ToDateTime(row["CreatedDate"].Equals(DBNull.Value)
                                    ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                    : row["CreatedDate"].ToString()),
                            ModifiedDate = Convert.ToDateTime(row["ModifiedDate"].Equals(DBNull.Value)
                                    ? DateTime.Now.ToString(CultureInfo.InvariantCulture)
                                    : row["ModifiedDate"].ToString()),
                            MaterialID =
                                Convert.ToInt16(row["MaterialID"].Equals(DBNull.Value)
                                    ? "0"
                                    : row["MaterialID"].ToString())
                        };

                        lsMateraial.Add(cs);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                return lsMateraial;
            }

        }

    }
}
