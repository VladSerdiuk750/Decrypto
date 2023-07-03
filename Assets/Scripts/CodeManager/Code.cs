using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Code 
{
    private List<int> _codeList;
   
    public List<int> CodeList => _codeList;

    public Code() 
    {
        _codeList = new List<int>();
    }
}