using IndiaCensusDataDemo.DataDAO;
using IndiaCensusDataDemo.DTO;
using System;
using System.Collections.Generic;

namespace IndiaCensusDataDemo
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDataDAO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    //case (CensusAnalyser.Country.US):
                    //    return new USCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);

                }
            }
            catch(CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}