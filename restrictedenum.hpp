/*
  C++ doesn't have the same type/value checking C# has,
  and without BOOST it's pretty much impossible to iterate
  over enum values. So this is simplified.
*/

#ifndef RESTRICTED_ENUM
#define RESTRICTED_ENUM

template<typename t>
class restrictedenum {
    private:
    t eflag;

    public:
    t get () {
        return eflag;
    };

    void set ( t flag ) {
        eflag = flag;
    };
};

#endif
