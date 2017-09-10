#pragma once
#include <algorithm>
#include "KryptonType.h"

/**
 * Helper function for determining system endianness
 */
bool is_big_endian() {
    union {
        uint32_t i;
        uint8_t c[4];
    } bint = {0x01020304};
    return bint.c[0] == 0x01;
}

namespace krypton {
template <
    typename ValueT,
    typename = typename std::enable_if<std::is_arithmetic<ValueT>::value, ValueT>::type
>
class KryptonNumeric : KryptonType {
public:
    union DataValue {
        char data[sizeof(ValueT)];
        ValueT value;
	};
    
    KryptonNumeric() { m_value = 0; }
    KryptonNumeric(ValueT value) { m_value = value; }

    void write(std::ostream& os) const {
        DataValue dv;
        dv.value = m_value;
        
#ifdef WRITE_BIG_ENDIAN
        if (!is_big_endian())
#else
        if (is_big_endian())
#endif
            std::reverse(&dv.data[0], &dv.data[sizeof(ValueT)]);

        os.write(dv.data, sizeof(ValueT));
    }

    void read(std::istream& is) {
        DataValue dv;
        is.read(&dv.data[0], sizeof(ValueT));

#ifdef WRITE_BIG_ENDIAN
        if (!is_big_endian())
#else
        if (is_big_endian())
#endif
            std::reverse(&dv.data[0], &dv.data[sizeof(ValueT)]);

        m_value = dv.value;
    }

	ValueT value() const {
		return m_value;
	}
private:
    ValueT m_value;
};

typedef KryptonNumeric<int8_t> KryptonInt8;
typedef KryptonInt8 kint8_t;
typedef KryptonNumeric<uint8_t> KryptonUInt8;
typedef KryptonUInt8 kuint8_t;

typedef KryptonNumeric<int16_t> KryptonInt16;
typedef KryptonInt16 kint16_t;
typedef KryptonNumeric<uint16_t> KryptonUInt16;
typedef KryptonUInt16 kuint16_t;

typedef KryptonNumeric<int32_t> KryptonInt32;
typedef KryptonInt32 kint32_t;
typedef KryptonNumeric<uint32_t> KryptonUInt32;
typedef KryptonUInt32 kuint32_t;

typedef KryptonNumeric<int64_t> KryptonInt64;
typedef KryptonInt64 kint64_t;
typedef KryptonNumeric<uint64_t> KryptonUInt64;
typedef KryptonUInt64 kuint64_t;
}
