using LibraryApi.EFcore;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace LibraryApi.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<relationmodel> Getrelation()
        {
            //GET
            List<relationmodel> response = new List<relationmodel>();
            List<relation> datalist = _context.relation.ToList();
            datalist.ForEach(row => response.Add(new relationmodel()
            {
                name = row.name,
                title = row.title,


            }));
            return response;
        }

        public void postrelation(relationmodel relationmodel)
        {
            var dbtable = _context.relation.Where(d => d.name == relationmodel.name
                                                  && d.title == relationmodel.title).FirstOrDefault();
            //POST
            if (dbtable == null)
            {
                var book = _context.books.Where(d => d.title == relationmodel.title).FirstOrDefault();

                if (book == null)
                {
                    book = new books();
                    book.title = relationmodel.title;
                    _context.books.Add(book);
                }

                var author = _context.authors.Where(d => d.name == relationmodel.name).FirstOrDefault();

                if (author == null)
                {
                    author = new authors();
                    author.name = relationmodel.name;
                    _context.authors.Add(author);

                }
                dbtable = new relation();
                dbtable.name = relationmodel.name;
                dbtable.title = relationmodel.title;
                _context.relation.Add(dbtable);

            }
            _context.SaveChanges();

        }

        public void deleterelation(relationmodel relationmodel)
        {
            //delete
            var entry = _context.relation.Where(d => d.name == relationmodel.name
                                                  && d.title == relationmodel.title).FirstOrDefault();
            if (entry != null)
            {
                _context.relation.Remove(entry);
                _context.SaveChanges();

                var deletebook = _context.books.Where(d => d.title == relationmodel.title).FirstOrDefault();
                if (deletebook != null) _context.books.Remove(deletebook);
                _context.SaveChanges();


                var deleteauthor = _context.authors.Where(d => d.name == relationmodel.name).FirstOrDefault();
                if (deleteauthor != null) _context.authors.Remove(deleteauthor);
                _context.SaveChanges();
            }
        }
        
        //public List<bookmodel> Getbooks()
        //{
        //    //GET
        //    List<bookmodel> response = new List<bookmodel>();
        //    List<books> booklist = _context.books.ToList();
        //    List<relation> datalist = _context.relation.ToList();
        //    booklist.ForEach(row => response.Add(new bookmodel()
        //    {
        //        title = row.title,
        //        DOP = row.DOP,
        //        language = row.language,
        //    }));
        //    foreach(bookmodel bookmodel in response)
        //    {
        //        List<relation> authorlist = datalist.Where(row => row.title == bookmodel.title).ToList();

        //        foreach(relation relation in authorlist)
        //        {
        //            bookmodel
        //        }

        //    }
        //    ;

            
        //}


    }
}


        