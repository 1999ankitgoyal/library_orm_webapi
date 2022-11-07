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

                var book = _context.relation.Where(d => d.title == relationmodel.title).FirstOrDefault();

                if (book == null)
                {
                    var deletebook = _context.books.Where(d => d.title == relationmodel.title).FirstOrDefault();
                    if (deletebook != null) _context.books.Remove(deletebook);
                    _context.SaveChanges();
                }

                var author = _context.relation.Where(d => d.name == relationmodel.name).FirstOrDefault();

                if (author == null)
                {
                    var deleteauthor = _context.authors.Where(d => d.name == relationmodel.name).FirstOrDefault();
                    if (deleteauthor != null) _context.authors.Remove(deleteauthor);
                    _context.SaveChanges();
                }
            }
        }

        public List<bookmodel> Getbooks()
        {
            //GET
            List<bookmodel> response = new List<bookmodel>();
            List<books> booklist = _context.books.ToList();
            List<relation> datalist = _context.relation.ToList();
            booklist.ForEach(row => response.Add(new bookmodel()
            {
                title = row.title,
                DOP = row.DOP,
                language = row.language,
            }));
            foreach (bookmodel bookmodel in response)
            {
                List<relation> authorlist = datalist.Where(row => row.title == bookmodel.title).ToList();

                foreach (relation relation in authorlist)
                {
                    bookmodel.name.Add(relation.name);
                }

            }
            return response;
        }

        public void Postbook(bookmodel bookmodel)
        {
            var book = _context.books.Where(d => d.title == bookmodel.title).FirstOrDefault();

            if (book == null)
            {
                //POST
                book = new books();
                book.title = bookmodel.title;
                book.DOP = bookmodel.DOP;
                book.language = bookmodel.language;
                _context.books.Add(book);
                _context.SaveChanges();
                foreach (string? authorname in bookmodel.name)
                {
                    var author = _context.authors.Where(d => d.name == authorname).FirstOrDefault();
                    if (author == null)
                    {
                        author = new authors();
                        author.name = authorname;
                        _context.authors.Add(author);
                        _context.SaveChanges();
                    }

                    var relation = _context.relation.Where(d => d.name == authorname && d.title == bookmodel.title).FirstOrDefault();
                    if (relation == null)
                    {
                        var newrelation = new relation();
                        newrelation.title = bookmodel.title;
                        newrelation.name = authorname;
                        _context.relation.Add(newrelation);
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                //PUT 
                book.DOP = bookmodel.DOP;
                book.language = bookmodel.language;
                _context.SaveChanges();
                foreach (string? authorname in bookmodel.name)
                {
                    var author = _context.authors.Where(d => d.name == authorname).FirstOrDefault();
                    if (author == null)
                    {
                        author = new authors();
                        author.name = authorname;
                        _context.authors.Add(author);
                        _context.SaveChanges();
                    }

                    var relation = _context.relation.Where(d => d.name == authorname && d.title == bookmodel.title).FirstOrDefault();
                    if (relation == null)
                    {
                        var newrelation = new relation();
                        newrelation.title = bookmodel.title;
                        newrelation.name = authorname;
                        _context.relation.Add(newrelation);
                        _context.SaveChanges();
                    }

                }
            }
        }

        public void Deletebook(bookmodel bookmodel)
        {
            var book = _context.books.Where(d => d.title == bookmodel.title).FirstOrDefault();
             
            if(book!= null)
            {
                _context.books.Remove(book);
                _context.SaveChanges();
            }
        }

        public List<authormodel> Getauthors()
        {
            //GET
            List<authormodel> response = new List<authormodel>();
            List<authors> authorlist = _context.authors.ToList();
            List<relation> datalist = _context.relation.ToList();
            authorlist.ForEach(row => response.Add(new authormodel()
            {
                name = row.name,
                DOB = row.DOB,
                country = row.country,
            }));
            foreach(authormodel authormodel in response)
            {
                List<relation> booklist = datalist.Where(row => row.name == authormodel.name).ToList();

                foreach(relation relation in booklist)
                {
                    authormodel.title.Add(relation.name);
                }

            }
            return response;
        }

        public void Postauthor(authormodel authormodel)
        {
            var author  = _context.authors.Where(d => d.name  == authormodel.name).FirstOrDefault();

            if (author == null)
            {
                //POST
                author = new authors();
                author.name = authormodel.name;
                author.DOB = authormodel.DOB;
                author.country = authormodel.country;
                _context.authors.Add(author);
                _context.SaveChanges();
                foreach (string? bookname in authormodel.title)
                {
                    var book = _context.books.Where(d => d.title == bookname).FirstOrDefault();
                    if (book == null)
                    {
                        book = new books();
                        book.title = bookname;
                        _context.books.Add(book);
                        _context.SaveChanges();
                    }

                    var relation = _context.relation.Where(d => d.title == bookname && d.name == authormodel.name).FirstOrDefault();
                    if (relation == null)
                    {
                        var newrelation = new relation();
                        newrelation.name = authormodel.name;
                        newrelation.title = bookname;
                        _context.relation.Add(newrelation);
                        _context.SaveChanges();
                    }

                }
            }
            else
            {
                //PUT 
                author.DOB = authormodel.DOB;
                author.country = authormodel.country;
                _context.SaveChanges();
                foreach (string? bookname in authormodel.title)
                {
                    var book = _context.books.Where(d => d.title == bookname).FirstOrDefault();
                    if (book == null)
                    {
                        book = new books();
                        book.title = bookname;
                        _context.books.Add(book);
                        _context.SaveChanges();
                    }

                    var relation = _context.relation.Where(d => d.title == bookname && d.name == authormodel.name).FirstOrDefault();
                    if (relation == null)
                    {
                        var newrelation = new relation();
                        newrelation.title = bookname;
                        newrelation.name = authormodel.name;
                        _context.relation.Add(newrelation);
                        _context.SaveChanges();
                    }

                }
            }
        }

        public void Deleteauthor(authormodel authormodel)
        {
            var author = _context.authors.Where(d => d.name == authormodel.name).FirstOrDefault();

            if (author != null)
            {
                _context.authors.Remove(author);
                _context.SaveChanges();
            }
        }

    }
}


        