using Hotel.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace Hotel.Models.DataAccessLayer
{
    class RoomDAL
    {
        public ObservableCollection<RoomType> GetAllRooms()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetRoomTypes", con);
                ObservableCollection<RoomType> result = new ObservableCollection<RoomType>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RoomType p = new RoomType();
                    var test = reader[0];
                    p.Room.CameraID = (Int64)(reader[0]);
                    p.CameraType = (string)(reader[1]);
                    p.Room.Price = Convert.ToSingle((reader[2]));
                    p.Room.Availability = (bool)(reader[3]);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public int getCameraTypeID(string CameraType)
        {
            int idCamera = 0;
            if (CameraType == "Single")
            {
                idCamera = 1;
            }
            if (CameraType == "Double")
            {
                idCamera = 2;
            }
            if (CameraType == "Triple")
            {
                idCamera = 3;
            }
            if (CameraType == "King")
            {
                idCamera = 4;
            }
            if (CameraType == "Queen")
            {
                idCamera = 5;
            }
            if (CameraType == "Apartment")
            {
                idCamera = 6;
            }
            if (CameraType == "Twin")
            {
                idCamera = 7;
            }
            if (CameraType == "Studio")
            {
                idCamera = 8;
            }
            if (CameraType == "Penthouse")
            {
                idCamera = 9;
            }
            return idCamera;
        }

        public void AddRoom(RoomType room)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                Int64 idCamera = getCameraTypeID(room.CameraType);
                
                SqlParameter paramIdCamera = new SqlParameter("@cameraID", idCamera);
                SqlParameter paramStatus = new SqlParameter("@status", room.Room.Availability);
                SqlParameter paramPrice = new SqlParameter("@price", room.Room.Price);

                cmd.Parameters.Add(paramIdCamera);
                cmd.Parameters.Add(paramStatus);
                cmd.Parameters.Add(paramPrice);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteRoom(RoomType room)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteRoom", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdRoom = new SqlParameter("@id", room.Room.CameraID);
                cmd.Parameters.Add(paramIdRoom);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRoom(RoomType room)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateRoom", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                int idCameraType = getCameraTypeID(room.CameraType);
                SqlParameter paramIdRoom = new SqlParameter("@roomID", room.Room.CameraID);
                SqlParameter paramCameraType = new SqlParameter("@cameraTypeID", idCameraType);
                SqlParameter paramStatus = new SqlParameter("@status", room.Room.Availability);
                SqlParameter paramPrice = new SqlParameter("@price", room.Room.Price);

                cmd.Parameters.Add(paramIdRoom);
                cmd.Parameters.Add(paramCameraType);
                cmd.Parameters.Add(paramStatus);
                cmd.Parameters.Add(paramPrice);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<RoomFeatures> GetRoomsWithFeatures()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetRoomWithFeatures", con);
                ObservableCollection<RoomFeatures> result = new ObservableCollection<RoomFeatures>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    RoomFeatures p = new RoomFeatures();
                    p.room.Room.CameraID = (Int64)(reader[0]);
                    p.Denumire.Add(reader[1].ToString());
                    p.room.CameraType = reader[2].ToString();
                    p.room.Room.Availability = (bool)reader[3];
                    p.room.Room.Price = float.Parse(reader[4].ToString());

                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
