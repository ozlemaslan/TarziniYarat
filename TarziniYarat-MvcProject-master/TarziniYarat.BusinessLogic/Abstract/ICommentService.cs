﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Abstract
{
    public interface ICommentService:IBaseService<Comment>
    {
        List<Comment> GetAllProductId(int? productID);
    }
}
