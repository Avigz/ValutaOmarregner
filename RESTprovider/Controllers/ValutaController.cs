using Microsoft.AspNetCore.Mvc;
using ValutaOmregner;

namespace RESTprovider.Controllers
{
    [Route("api/Valuta")]
    [ApiController]
    public class ValutaController : ControllerBase
    {
        [HttpGet]
        public string LandingPage()
        {
            string result = "Benyt en af underdomaenerne: \n GET: api/Valuta/SEKTILDKK/100 \n GET: api/Valuta/DKKTILSEK/100 \n GET: api/Valuta/NyKurs/1 \n GET: api/Valuta/OriginalKurs  ";
            return result;
        }

        // GET: api/Valuta/SEKTILDKK/100
        [HttpGet]
        [Route("SEKTILDKK/{SEK}")]
        public double SEKDKK(double SEK)
        {
            double result = ValutaOmregner.Omregn.TilDanskeKroner(SEK);
            return result;
        }

        // GET: api/Valuta/DKKTILSEK/100
        [HttpGet]
        [Route("DKKTILSEK/{DKK}")]
        public double DKKSEK(double DKK)
        {
            double result = ValutaOmregner.Omregn.TilSvenskeKroner(DKK);
            return result;
        }

        // GET: api/Valuta/KURS/1
        [HttpGet]
        [Route("NyKurs/{nykurs}")]
        public string KURS(double nykurs)
        {
            ValutaOmregner.Omregn.valutakurs = nykurs;
            string result = "Ny kurs for SEK =" + ValutaOmregner.Omregn.valutakurs + "i DKK" ;
            return result;
        }
        // GET: api/Valuta/OriginalKurs
        [HttpGet]
        [Route("OriginalKurs")]
        public string ResetKurs()
        {
            ValutaOmregner.Omregn.valutakurs = 0.7041;
            string result = "Ny kurs for SEK =" + ValutaOmregner.Omregn.valutakurs + "i DKK";
            return result;
        }
    }
}
