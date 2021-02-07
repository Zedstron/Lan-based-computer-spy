using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class SearcherParams
{
    // ----- Variables -----

    private String m_searchDir;
    private Boolean m_includeSubDirsChecked;
    private List<String> m_fileNames;
    private Boolean m_newerThanChecked;
    private DateTime m_newerThanDateTime;
    private Boolean m_olderThanChecked;
    private DateTime m_olderThanDateTime;
    private Boolean m_containingChecked;
    private String m_containingText;
    private Encoding m_encoding;


    // ----- Constructor -----

    public SearcherParams(String searchDir,
        Boolean includeSubDirsChecked,
        List<String> fileNames,
        Boolean newerThanChecked,
        DateTime newerThanDateTime,
        Boolean olderThanChecked,
        DateTime olderThanDateTime,
        Boolean containingChecked,
        String containingText,
        Encoding encoding)
    {
        m_searchDir = searchDir;
        m_includeSubDirsChecked = includeSubDirsChecked;
        m_fileNames = fileNames;
        m_newerThanChecked = newerThanChecked;
        m_newerThanDateTime = newerThanDateTime;
        m_olderThanChecked = olderThanChecked;
        m_olderThanDateTime = olderThanDateTime;
        m_containingChecked = containingChecked;
        m_containingText = containingText;
        m_encoding = encoding;
    }


    // ----- Public Properties -----

    public String SearchDir
    {
        get { return m_searchDir; }
    }

    public Boolean IncludeSubDirsChecked
    {
        get { return m_includeSubDirsChecked; }
    }

    public List<String> FileNames
    {
        get { return m_fileNames; }
    }

    public Boolean NewerThanChecked
    {
        get { return m_newerThanChecked; }
    }

    public DateTime NewerThanDateTime
    {
        get { return m_newerThanDateTime; }
    }

    public Boolean OlderThanChecked
    {
        get { return m_olderThanChecked; }
    }

    public DateTime OlderThanDateTime
    {
        get { return m_olderThanDateTime; }
    }

    public Boolean ContainingChecked
    {
        get { return m_containingChecked; }
    }

    public String ContainingText
    {
        get { return m_containingText; }
    }

    public Encoding Encoding
    {
        get { return m_encoding; }
    }
}

