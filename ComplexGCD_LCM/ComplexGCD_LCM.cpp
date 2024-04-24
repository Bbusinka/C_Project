#include <iostream>
#include <tuple>

using namespace std;

// Struktura reprezentująca liczbę Gaussa a+bi
struct Gauss {
    int a, b;
};

// Funkcja dzielenia z resztą w pierścieniu liczb Gaussa
tuple<Gauss, Gauss> div(const Gauss& x, const Gauss& y) {
    int den = y.a * y.a + y.b * y.b;
    int x_ = (x.a * y.a + x.b * y.b) / den;
    int y_ = (x.b * y.a - x.a * y.b) / den;
    int a_ = x.a - x_ * y.a + y_ * y.b;
    int b_ = x.b - x_ * y.b - y_ * y.a;
    return make_tuple(Gauss{x_, y_}, Gauss{a_, b_});
}

// Funkcja znajdująca NWD dla liczb Gaussa
Gauss nwd(const Gauss& u, const Gauss& v) {
    Gauss r1 = u, r2 = v, temp;
    while (r2.a != 0 || r2.b != 0) {
        temp = r2;
        auto qr = div(r1, r2);
        r2 = get<1>(qr);
        r1 = temp;
    }
    return r1;
}

// Funkcja znajdująca NWW dla liczb Gaussa
Gauss nww(const Gauss& u, const Gauss& v) {
    int a = u.a*v.a - u.b*v.b;
    int b = u.a*v.b + u.b*v.a; 
    Gauss ab{a,b};
    tuple<Gauss, Gauss> result = div(ab, nwd(u,v));
    return get<0>(result);
}

int main() {
    // (3+4i, 1+3i) = (2+i)
    Gauss u{3, 4}, v{1, 3};
    Gauss c = nwd(u, v);
    cout << "NWD(3 + 4i, 1 + 3i) = (" << c.a << " + " << c.b << "i)" << endl;

    // (3+4i) ∩ (1+3i) = (1+i)(2+i)^2 = (-1+7i)
    Gauss d = nww(u, v);
    cout << "NWW(3 + 4i, 1 + 3i) = (" << d.a << " + " << d.b << "i)" << endl;

    return 0;
}
