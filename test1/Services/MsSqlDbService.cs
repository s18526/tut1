using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tutorial8.DTOs.Responses;
using Tutorial8.Models;

namespace Tutorial8.Services
{
    public class MsSqlDbService:IDbService
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18526;Integrated Security=True";

        public bool isTaskExists(int TaskId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select 1 from Task where IdTask=@index";
                    com.Parameters.AddWithValue("@index",TaskId);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TaskRequestResponse requestDataById(string TaskId)
        {
            int id = 0;
            try
            {
                id = Int32.Parse(TaskId);
                
                using (SqlConnection con = new SqlConnection(ConString))
                using (SqlCommand com = new SqlCommand())
                {
                    com.Parameters.Clear();
                    com.Connection = con;
                    com.CommandText = "Select Task.IdTask,Task.Name \"TaskName\" ,Task.Description,Task.Deadline,Project.Name \"ProjectName\",TaskType.Name \"TaskType\" ,Assigned.LastName \"AssignedLastName\",Creator.LastName \"CreatorLastName\" from Task inner join Project on Task.IdProject=Project.IdProject inner join TaskType on Task.IdTask=TaskType.IdTaskType inner join TeamMember \"Creator\" on Task.IdCreator=Creator.IdTeamMember inner join TeamMember \"Assigned\" on Task.IdAssignedTo=Assigned.IdTeamMember where Task.IdTask=@index order by Task.Deadline Desc;";
                    com.Parameters.AddWithValue("@index", id);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        TaskRequestResponse response = new TaskRequestResponse();
                        while (reader.Read())
                        {
                            Models.Task tmpTask = new Models.Task();
                            tmpTask.TaskId = int.Parse(reader["IdTask"].ToString());
                            tmpTask.TaskName = reader["TaskName"].ToString();
                            tmpTask.TaskProjectName = reader["ProjectName"].ToString();
                            tmpTask.Deadline = DateTime.Parse(reader["Deadline"].ToString());
                            tmpTask.TaskType = reader["TaskType"].ToString();
                            tmpTask.Description = reader["Description"].ToString();
                            tmpTask.CreatorLastName = reader["CreatorLastName"].ToString();
                            tmpTask.AssignedToLastName = reader["AssignedLastName"].ToString();
                            response.taskList.Add(tmpTask);
                        }
                        reader.Close();
                        return response;
                    }
                    reader.Close();
                    return new TaskRequestResponse();
                }
            }
            catch(Exception ex) {
                return returnAllTasks();
            }
        }

        public TaskRequestResponse returnAllTasks()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select Task.IdTask,Task.Name \"TaskName\" ,Task.Description,Task.Deadline,Project.Name \"ProjectName\",TaskType.Name \"TaskType\" ,Assigned.LastName \"AssignedLastName\",Creator.LastName \"CreatorLastName\" from Task inner join Project on Task.IdProject=Project.IdProject inner join TaskType on Task.IdTask=TaskType.IdTaskType inner join TeamMember \"Creator\" on Task.IdCreator=Creator.IdTeamMember inner join TeamMember \"Assigned\" on Task.IdAssignedTo=Assigned.IdTeamMember order by Task.Deadline Desc;";
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        TaskRequestResponse response = new TaskRequestResponse();
                        while (reader.Read()) {
                            Models.Task tmpTask = new Models.Task();
                            tmpTask.TaskId = int.Parse(reader["IdTask"].ToString());
                            tmpTask.TaskName = reader["TaskName"].ToString();
                            tmpTask.TaskProjectName = reader["ProjectName"].ToString();
                            tmpTask.Deadline = DateTime.Parse(reader["Deadline"].ToString());
                            tmpTask.TaskType = reader["TaskType"].ToString();
                            tmpTask.Description = reader["Description"].ToString();
                            tmpTask.CreatorLastName = reader["CreatorLastName"].ToString();
                            tmpTask.AssignedToLastName = reader["AssignedLastName"].ToString();
                            response.taskList.Add(tmpTask);
                        }
                        reader.Close();
                        return response;
                    }
                    reader.Close();
                    return new TaskRequestResponse();
                }
            }
            catch (Exception ex)
            {
                return new TaskRequestResponse();
            }
        }
    }
}
