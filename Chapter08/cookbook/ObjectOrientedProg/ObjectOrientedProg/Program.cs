using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProg
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Using inheritance in C#
            //SpaceShip transporter = new SpaceShip();
            //transporter.ControlBridge();
            //transporter.CrewQuarters(1500);
            //transporter.EngineRoom(2);
            //transporter.MedicalBay(350);
            //transporter.TeleportationRoom();

            //Destroyer warShip = new Destroyer();
            //warShip.Armory(6);
            //warShip.ControlBridge();
            //warShip.CrewQuarters(2200);
            //warShip.EngineRoom(4);
            //warShip.MedicalBay(800);
            //warShip.TeleportationRoom();
            //warShip.WarRoom();
            //warShip.WarSpecialists(1);

            //Annihilator planetClassDestroyer = new Annihilator();
            //planetClassDestroyer.Armory(12);
            //planetClassDestroyer.ControlBridge();
            //planetClassDestroyer.CrewQuarters(4500);
            //planetClassDestroyer.EngineRoom(7);
            //planetClassDestroyer.MedicalBay(3500);
            //planetClassDestroyer.PlanetDestructionCapability();
            //planetClassDestroyer.TeleportationRoom();
            //planetClassDestroyer.TractorBeam();
            //planetClassDestroyer.WarRoom();
            //planetClassDestroyer.WarSpecialists(3); 
            #endregion

            #region Leveraging encapsulation
            double thrust = 220; // kN 
            double shuttleMass = 16.12; // t 
            double graviatatonalAccelerationEarth = 9.81;
            double earthMass = 5.9742 * Math.Pow(10, 24);
            double earthRadius = 6378100;
            double thrustToWeightRatio = 0;

            LaunchShuttle NasaShuttle1 = new LaunchShuttle(thrust, shuttleMass, graviatatonalAccelerationEarth);
            thrustToWeightRatio = NasaShuttle1.TWR();
            Console.WriteLine(thrustToWeightRatio);

            LaunchShuttle NasaShuttle2 = new LaunchShuttle(thrust, shuttleMass, LaunchShuttle.Planet.Earth);
            thrustToWeightRatio = NasaShuttle2.TWR();
            Console.WriteLine(thrustToWeightRatio);

            LaunchShuttle NasaShuttle3 = new LaunchShuttle(thrust, shuttleMass, earthMass, earthRadius);
            thrustToWeightRatio = NasaShuttle3.TWR();
            Console.WriteLine(thrustToWeightRatio);

            Console.Read();
            #endregion

            #region Exception Handling
            //Chapter3 ch3 = new Chapter3();
            //string File = @"c:\temp\XmlFile.xml";
            //ch3.ReadXMLFile(File); 
            #endregion
        }
    }

    

    #region Using inheritance in C#
    public class Annihilator : Destroyer
    {
        public void TractorBeam()
        {

        }

        public void PlanetDestructionCapability()
        {

        }
    }

    public class Destroyer : SpaceShip
    {
        public void WarRoom()
        {

        }
        public void Armory(int payloadCapacity)
        {

        }

        public void WarSpecialists(int activeBattalions)
        {

        }
    }

    public class SpaceShip
    {
        public void ControlBridge()
        {

        }
        public void MedicalBay(int patientCapacity)
        {

        }
        public void EngineRoom(int warpDrives)
        {

        }
        public void CrewQuarters(int crewCapacity)
        {

        }
        public void TeleportationRoom()
        {

        }
    }
    #endregion

    #region Using abstraction
    public class PlanetExplorer : SpacePrivate
    {
        public override void AdvancedCommunicationSkill()
        {
            throw new NotImplementedException();
        }

        public override void AdvancedWeaponsTraining()
        {
            throw new NotImplementedException();
        }

        public override void BasicCommunicationSkill()
        {
            throw new NotImplementedException();
        }

        public override void BasicWeaponsTraining()
        {
            throw new NotImplementedException();
        }

        public override void ChartingStarMaps()
        {
            throw new NotImplementedException();
        }

        public override void Negotiation()
        {
            throw new NotImplementedException();
        }

        public override void Persuader()
        {
            throw new NotImplementedException();
        }
    }

    public class LabResearcher : SpaceCadet
    {
        public override void BasicCommunicationSkill()
        {
            throw new NotImplementedException();
        }

        public override void BasicWeaponsTraining()
        {
            throw new NotImplementedException();
        }

        public override void ChartingStarMaps()
        {
            throw new NotImplementedException();
        }

        public override void Negotiation()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class SpacePrivate : SpaceCadet
    {
        public abstract void AdvancedCommunicationSkill();
        public abstract void AdvancedWeaponsTraining();
        public abstract void Persuader();
    }

    public abstract class SpaceCadet
    {
        public abstract void ChartingStarMaps();
        public abstract void BasicCommunicationSkill();
        public abstract void BasicWeaponsTraining();
        public abstract void Negotiation();
    }
    #endregion
    
    #region Leveraging encapsulation
    public class LaunchShuttle
    {
        private double _EngineThrust;
        private double _TotalShuttleMass;
        private double _LocalGravitationalAcceleration;

        private const double EarthGravity = 9.81;
        private const double MoonGravity = 1.63;
        private const double MarsGravity = 3.75;
        private double UniversalGravitationalConstant;

        public enum Planet { Earth, Moon, Mars }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, double gravitationalAcceleration)
        {
            _EngineThrust = engineThrust;
            _TotalShuttleMass = totalShuttleMass;
            _LocalGravitationalAcceleration = gravitationalAcceleration;

        }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, Planet planet)
        {
            _EngineThrust = engineThrust;
            _TotalShuttleMass = totalShuttleMass;
            SetGraviationalAcceleration(planet);

        }

        public LaunchShuttle(double engineThrust, double totalShuttleMass, double planetMass, double planetRadius)
        {
            _EngineThrust = engineThrust;
            _TotalShuttleMass = totalShuttleMass;
            SetUniversalGravitationalConstant();
            _LocalGravitationalAcceleration = Math.Round(CalculateGravitationalAcceleration(planetRadius, planetMass), 2);
        }

        private void SetGraviationalAcceleration(Planet planet)
        {
            switch (planet)
            {
                case Planet.Earth:
                    _LocalGravitationalAcceleration = EarthGravity;
                    break;
                case Planet.Moon:
                    _LocalGravitationalAcceleration = MoonGravity;
                    break;
                case Planet.Mars:
                    _LocalGravitationalAcceleration = MarsGravity;
                    break;
                default:
                    break;
            }
        }

        private void SetUniversalGravitationalConstant()
        {
            UniversalGravitationalConstant = 6.6726 * Math.Pow(10, -11);
        }

        private double CalculateThrustToWeightRatio()
        {
            // TWR = Ft/m.g > 1 
            return _EngineThrust / (_TotalShuttleMass * _LocalGravitationalAcceleration);
        }

        private double CalculateGravitationalAcceleration(double radius, double mass)
        {
            return (UniversalGravitationalConstant * mass) / Math.Pow(radius, 2);
        }

        public double TWR()
        {
            return Math.Round(CalculateThrustToWeightRatio(), 2);
        }


    }
    #endregion
    
    #region Implementing polymorphism
    public class NasaShuttle : Shuttle
    {
        public override double TWR()
        {
            throw new NotImplementedException();
        }
    }


    public class RoscosmosShuttle : Shuttle
    {
        public override double TWR()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Shuttle
    {
        public abstract double TWR();
    }
    #endregion
    
    #region Single responsibility principle
    public class Starship
    {
        public void SetMaximumTroopCapacity(int capacity)
        {
            try
            {
                // Read current capacity and try to add more 
            }
            catch (Exception ex)
            {
                string connectionString = "connection string goes  here"; string sql = $"INSERT INTO tblLog (error, date) VALUES  ({ex.Message}, GetDate())"; using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                throw ex;
            }
        }
    }
    #endregion
    
    #region Open/closed principle
    public class StarTrooper
    {
        public enum TrooperClass { Soldier, Medic, Scientist }
        List<string> TroopSkill;

        public List<string> GetSkills(TrooperClass troopClass)
        {
            switch (troopClass)
            {
                case TrooperClass.Soldier:
                    return TroopSkill = new List<string>(new string[] { "Weaponry", "TacticalCombat", "HandToHandCombat" });

                case TrooperClass.Medic:
                    return TroopSkill = new List<string>(new string[] { "CPR", "AdvancedLifeSupport" });

                case TrooperClass.Scientist:
                    return TroopSkill = new List<string>(new string[] { "Chemistry", "MollecularDeconstruction", "QuarkTheory" });

                default:
                    return TroopSkill = new List<string>(new string[] { "none" });
            }
        }
    }


    public class Trooper
    {
        public virtual List<string> GetSkills()
        {
            return new List<string>(new string[] { "none" });
        }
    }

    public class Soldier : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "Weaponry", "TacticalCombat", "HandToHandCombat" });
        }
    }

    public class Medic : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "CPR", "AdvancedLifeSupport" });
        }
    }

    public class Scientist : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "Chemistry", "MollecularDeconstruction", "QuarkTheory" });
        }
    }

    public class Engineer : Trooper
    {
        public override List<string> GetSkills()
        {
            return new List<string>(new string[] { "Construction", "Demolition" });
        }
    }
    #endregion

    #region Exception Handling
    public class Chapter3
    {
        #region Old Exception
        //public void ReadXMLFile(string fileName)
        //{
        //    try
        //    {
        //        bool blnReadFileFlag = true;
        //        if (blnReadFileFlag)
        //        {
        //            File.ReadAllLines(fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(ex);
        //        throw;
        //    }
        //}
        //private void Log(Exception e)
        //{
        //    /* Log the error */
        //} 

        #endregion

        #region New Exception Handling with Filters
        public void ReadXMLFile(string fileName)
        {
            try
            {
                bool blnReadFileFlag = true;
                if (blnReadFileFlag)
                {
                    File.ReadAllLines(fileName);
                }
            }
            catch (Exception ex) when (Log(ex))
            {
            }
        }
        private bool Log(Exception e)
        {
            /* Log the error */
            return false;
        }
        #endregion

        #region Exception Retry Count
        public void TryReadXMLFile(string fileName)
        {
            bool blnFileRead = false;
            do
            {
                int iTryCount = 0;
                try
                {
                    bool blnReadFileFlag = true;
                    if (blnReadFileFlag)
                        File.ReadAllLines(fileName);
                }
                catch (Exception ex) when (RetryRead(ex, iTryCount++) == true)
                {
                }
            } while (!blnFileRead);
        }
        private bool RetryRead(Exception e, int tryCount)
        {
            bool blnThrowEx = tryCount <= 10 ? blnThrowEx = false : blnThrowEx
            = true;
            /* Log the error if blnThrowEx = false */
            return blnThrowEx;
        }
        #endregion
    } 
    #endregion

}
