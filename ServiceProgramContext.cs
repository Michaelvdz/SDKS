using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Service_Program
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ServiceProgramContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<CheckUp> CheckUps { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<PresetDevs> DefaultDevices { get; set; }
    }

}
