using IndiaCensusDataDemo;
using IndiaCensusDataDemo.DataDAO;

namespace IndiaCensusData
{
    public class Tests
    {
        string stateCodePath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        string stateCensusPath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateData.csv";
        string wrongStateCodePath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaCode.csv";
        string wrongTypeStateCodePath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCodePath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCode.csv";
        string wrongHeaderStateCensusPath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCodePath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimiterIndiaStateCode.csv";
        string delimiterStateCensusPath = @"D:\dotnet\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\CSVFiles\DelimiterIndiaStateCensusData.csv";
        IndiaCensusDataDemo.CSVAdapterFactory csv = null;
        //Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDataDAO> stateRecords;

        [SetUp]
        public void Setup()
        {
            csv = new IndiaCensusDataDemo.CSVAdapterFactory();
            // totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }

        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [Test]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndiaCensusDataDemo.CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
        /// TC 1.2
        /// Giving incorrect path should return file not found custom exception
        [Test]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                //total no of rows excluding header are 29 in indian state census data.
                //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 1.3
        /// Giving wrong type of path should return invalid file type custom exception
        [Test]
        public void GivenWrongTypeReturnsCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [Test]
        public void GivenWrongDelimeterReturnsCustomException()
        {
            try
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.5
        /// Giving wrong header type should return incorrect header type custom exception
        [Test]
        public void GivenWrongHeaderReturnsCustomException()
        {
            try
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 2.1
        /// Giving the correct path it should return the total count from the census
        [Test]
        public void GivenStateCodeReturnCount()
        {
            //totalRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State Name,TIN,StateCode");
            //Assert.AreEqual(37, totalRecords.Count);
        }
        /// TC 2.2
        /// Giving incorrect path should return file not found custom exception
        [Test]
        public void GivenIncorrectPathCodeCustomException()
        {
            var stateCustomException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateCustomException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 2.3
        /// Giving wrong type of path should return invalid file type custom exception
        [Test]
        public void GivenIncorrectPathTypeCodeReturnException()
        {
            var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        /// TC 2.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [Test]
        public void GivenWrongHeaderStateCodeReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        /// TC 2.5
        /// Giving wrong header type should return incorrect header type custom exception
        [Test]
        public void GivenWrongDelimiterCodeReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }
    }
}