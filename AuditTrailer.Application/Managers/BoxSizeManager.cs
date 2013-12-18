using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Managers
{
    using AuditTrailer.Application.Database;
    using AuditTrailer.Application.Model;

    public class BoxSizeManager
    {
        private DatabaseConnection connection;

        public BoxSizeManager(DatabaseConnection _connection)
        {
            connection = _connection;
        }

        public MedicineBoxSize GetMedicineBoxSize(PainReliever reliever, int size)
        {
            var command =
                connection.CreateCommand(
                    "SELECT MBZ.MedicineBoxSizeID, B.BoxSizeID FROM MedicineBoxSize MBZ "
                    + "JOIN BoxSize B ON B.BoxSizeID = MBZ.BoxSizeID WHERE MBZ.MedicineID = @MedicineID"
                    + " AND B.Name = @BoxSizeID");
            command.Parameters.AddWithValue("@MedicineID", reliever.ID);
            command.Parameters.AddWithValue("@BoxSizeID", size);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var medicineBoxSize = new MedicineBoxSize();
                    medicineBoxSize.ID = int.Parse(reader["MedicineBoxSizeID"].ToString());
                    medicineBoxSize.BoxSizeID = int.Parse(reader["BoxSizeID"].ToString());
                    return medicineBoxSize;
                }
            }

            return new MedicineBoxSize();
        }

        public BoxSize GetBoxSize(int size)
        {
            var command = connection.CreateCommand(@"SELECT * FROM BoxSize WHERE Name = @Name");
            command.Parameters.AddWithValue("@Name", size);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new BoxSize { ID = int.Parse(reader["BoxSizeID"].ToString()), Name = size };
                }
            }

            return new BoxSize();
        }


    }
}
