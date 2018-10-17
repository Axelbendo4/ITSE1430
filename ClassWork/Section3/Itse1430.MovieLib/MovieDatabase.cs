﻿using System;
using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    /// <summary>Manages a set of movies.</summary>
    public class MovieDatabase
    {
        #region Construction

        /// <summary>Initializes an instance of the <see cref="MovieDatabase"/> class.</summary>
        /// <remarks>
        /// The database is seeded with some movies.
        /// </remarks>
        public MovieDatabase() : this(true)
        {
        }

        /// <summary>Initializes an instance of the <see cref="MovieDatabase"/> class.</summary>
        /// <param name="seed">true to seed the database with movies.</param>        
        public MovieDatabase( bool seed ) : this(GetSeedMovies(seed))
        {
            //Ctor chaining eliminates the need to replicate this logic
            //if (seed)
            //{
            //    var movie = new Movie();
            //    movie.Name = "Jaws";
            //    movie.RunLength = 120;
            //    movie.ReleaseYear = 1977;
            //    Add(movie);

            //    movie = new Movie();
            //    movie.Name = "What About Bob?";
            //    movie.RunLength = 96;
            //    movie.ReleaseYear = 2004;
            //    Add(movie);
            //};
        }

        /// <summary>Initializes an instance of the <see cref="MovieDatabase"/> class.</summary>
        /// <param name="movies">The list of movies to initialize the database with.</param>
        public MovieDatabase( Movie[] movies )
        {
            _items.AddRange(movies);
            //for (var index = 0; index < movies.Length; ++index)
            //    _movies[index] = movies[index];
        }
        #endregion

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        public void Add( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return;

            AddCore(movie);
        }

        protected abstract void AddCore ( Movie movie );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        public Movie[] GetAll()
        {
            return GetAllCore();
        }

        protected abstract Movie[] GetAllCore();

        /// <summary>Edits an existing movie.</summary>
        /// <param name="name">The movie to edit.</param>
        /// <param name="movie">The new movie.</param>
        public void Edit( string name, Movie movie )
        {
            //TODO: Validate
            if (String.IsNullOrEmpty(name))
                return;
            if (movie == null)
                return;

            //Find movie by name
            var existing = FindByName(name);
            if (existing == null)
                return;

            EditCore(existing, movie);
        }

        protected abstract Movie FindByName( string name );
        protected abstract void EditCore( Movie oldMovie, Movie newMovie );

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        public void Remove( string name )
        {
            //TODO: Validate
            if (String.IsNullOrEmpty(name))
                return;

            RemoveCore(name);
        }
        protected abstract void RemoveCore( string name );

        #region Private Members
                
        //Gets some movies to see database with
        private static Movie[] GetSeedMovies( bool seed )
        {
            if (!seed)
                return new Movie[0];

            return new [] {
                new Movie() {
                    Name = "Jaws",
                    RunLength = 120,
                    ReleaseYear = 1977,
                },
                new Movie() {
                    Name = "What About Bob?",
                    RunLength = 96,
                    ReleaseYear = 2004,
                },
            };
        }
        #endregion
    }
}
