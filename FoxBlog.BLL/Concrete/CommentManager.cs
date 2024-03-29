﻿using Core.Aspects.Autofac.Validation;
using FoxBlog.BLL.Abstract;
using FoxBlog.BLL.ValidationRules.FluentValidation;
using FoxBlog.DAL.Abstract;
using FoxBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxBlog.BLL.Concrete
{
   public class CommentManager:ICommentService
    {
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        private ICommentDal _commentDal;

        [ValidationAspect(typeof(CommentValidator))]
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public Comment Find(int id)
        {
            return _commentDal.Find(x => x.ID.Equals(id));
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList().Where(x=>x.isActive.Equals(true)).OrderByDescending(x => x.ID).ToList();
        }

        public void Remove(Comment comment)
        {
            _commentDal.Remove(comment);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }

    }
}
