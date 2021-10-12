using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace asp.netcorewebapiEF.Models
{
    public partial class UngDungQuanLyThuVienContext : DbContext
    {
        public UngDungQuanLyThuVienContext()
        {
        }

        public UngDungQuanLyThuVienContext(DbContextOptions<UngDungQuanLyThuVienContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietphieumuon> Chitietphieumuons { get; set; }
        public virtual DbSet<Docgium> Docgia { get; set; }
        public virtual DbSet<Ke> Kes { get; set; }
        public virtual DbSet<Khu> Khus { get; set; }
        public virtual DbSet<Nhaxuatban> Nhaxuatbans { get; set; }
        public virtual DbSet<Phieumuon> Phieumuons { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Taikhoandocgium> Taikhoandocgia { get; set; }
        public virtual DbSet<Taikhoanthuthu> Taikhoanthuthus { get; set; }
        public virtual DbSet<Thedocgium> Thedocgia { get; set; }
        public virtual DbSet<Theloai> Theloais { get; set; }
        public virtual DbSet<Thuthu> Thuthus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Initial Catalog=UngDungQuanLyThuVien;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Chitietphieumuon>(entity =>
            {
                entity.HasKey(e => e.MaMuonTra)
                    .HasName("PK__CHITIETP__2E4C717E7E2FB338");

                entity.ToTable("CHITIETPHIEUMUON");

                entity.Property(e => e.MaPhieuMuon)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaSach)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayTraThat).HasColumnType("date");

                entity.Property(e => e.TinhTrang).HasMaxLength(100);

                entity.HasOne(d => d.MaPhieuMuonNavigation)
                    .WithMany(p => p.Chitietphieumuons)
                    .HasForeignKey(d => d.MaPhieuMuon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETPHI594320");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.Chitietphieumuons)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCHITIETPHI151328");
            });

            modelBuilder.Entity<Docgium>(entity =>
            {
                entity.HasKey(e => e.MaDocGia)
                    .HasName("PK__DOCGIA__F165F9450220F06D");

                entity.ToTable("DOCGIA");

                entity.Property(e => e.MaDocGia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(50)
                    .HasColumnName("CMND");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NamSinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai).HasMaxLength(50);

                entity.Property(e => e.TenDocGia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaTaiKhoaiNavigation)
                    .WithMany(p => p.Docgia)
                    .HasForeignKey(d => d.MaTaiKhoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDOCGIA564624");
            });

            modelBuilder.Entity<Ke>(entity =>
            {
                entity.HasKey(e => e.MaKe)
                    .HasName("PK__KE__2725CF7D67ED425E");

                entity.ToTable("KE");

                entity.Property(e => e.MaKe)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaKhu)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenKe)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaKhuNavigation)
                    .WithMany(p => p.Kes)
                    .HasForeignKey(d => d.MaKhu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKKE229454");
            });

            modelBuilder.Entity<Khu>(entity =>
            {
                entity.HasKey(e => e.MaKhu)
                    .HasName("PK__KHU__3BDA934AE3049FCA");

                entity.ToTable("KHU");

                entity.Property(e => e.MaKhu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenKhu)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Nhaxuatban>(entity =>
            {
                entity.HasKey(e => e.MaNhaXuatBan)
                    .HasName("PK__NHAXUATB__1AED0BFAF558361D");

                entity.ToTable("NHAXUATBAN");

                entity.Property(e => e.MaNhaXuatBan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DiaChiWebsite).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai).HasMaxLength(50);

                entity.Property(e => e.TenNhaXuatBan)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Phieumuon>(entity =>
            {
                entity.HasKey(e => e.MaPhieuMuon)
                    .HasName("PK__PHIEUMUO__C4C82222B929B2DE");

                entity.ToTable("PHIEUMUON");

                entity.Property(e => e.MaPhieuMuon)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaTheDocGia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgayMuon).HasColumnType("date");

                entity.Property(e => e.NgayTraDukien).HasColumnType("date");

                entity.HasOne(d => d.MaTaiKhoaiNavigation)
                    .WithMany(p => p.Phieumuons)
                    .HasForeignKey(d => d.MaTaiKhoai)
                    .HasConstraintName("FKPHIEUMUON160465");

                entity.HasOne(d => d.MaTheDocGiaNavigation)
                    .WithMany(p => p.Phieumuons)
                    .HasForeignKey(d => d.MaTheDocGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKPHIEUMUON685748");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId);

                entity.ToTable("RefreshToken");

                entity.Property(e => e.TokenId)
                    .ValueGeneratedNever()
                    .HasColumnName("token_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("token");

                entity.HasOne(d => d.MaTaiKhoaiNavigation)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.MaTaiKhoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshToken_TAIKHOANTHUTHU");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__SACH__B235742D675B6584");

                entity.ToTable("SACH");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HinhAnh)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaKe)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhaXuatBan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaTheLoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NguoiDich).HasMaxLength(255);

                entity.Property(e => e.NoiDungTomTat).HasMaxLength(255);

                entity.Property(e => e.TacGia).HasMaxLength(255);

                entity.Property(e => e.TenSach).HasMaxLength(255);

                entity.HasOne(d => d.MaKeNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaKe)
                    .HasConstraintName("FKSACH318768");

                entity.HasOne(d => d.MaNhaXuatBanNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaNhaXuatBan)
                    .HasConstraintName("FKSACH752561");

                entity.HasOne(d => d.MaTheLoaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaTheLoai)
                    .HasConstraintName("FKSACH567542");
            });

            modelBuilder.Entity<Taikhoandocgium>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoaiDocGia)
                    .HasName("PK__TAIKHOAN__2701A533FD95743D");

                entity.ToTable("TAIKHOANDOCGIA");

                entity.Property(e => e.MaDocGia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenTaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaDocGiaNavigation)
                    .WithMany(p => p.Taikhoandocgia)
                    .HasForeignKey(d => d.MaDocGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTAIKHOANDO410979");

                entity.HasOne(d => d.MaTaiKhoaiNavigation)
                    .WithMany(p => p.Taikhoandocgia)
                    .HasForeignKey(d => d.MaTaiKhoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTAIKHOANDO997262");
            });

            modelBuilder.Entity<Taikhoanthuthu>(entity =>
            {
                entity.HasKey(e => e.MaTaiKhoai)
                    .HasName("PK__TAIKHOAN__AD7C652C938C0D44");

                entity.ToTable("TAIKHOANTHUTHU");

                entity.Property(e => e.MaThuThu)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenTaiKhoai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaThuThuNavigation)
                    .WithMany(p => p.Taikhoanthuthus)
                    .HasForeignKey(d => d.MaThuThu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTAIKHOANTH192785");
            });

            modelBuilder.Entity<Thedocgium>(entity =>
            {
                entity.HasKey(e => e.MaTheDocGia)
                    .HasName("PK__THEDOCGI__BA67A41E530CAAF9");

                entity.ToTable("THEDOCGIA");

                entity.Property(e => e.MaTheDocGia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamSinh).HasColumnType("date");

                entity.Property(e => e.NgayTheDuocGiaHan).HasColumnType("date");

                entity.Property(e => e.NgayTheDuocTao).HasColumnType("date");

                entity.Property(e => e.TenDocGia).HasMaxLength(100);

                entity.HasOne(d => d.MaTaiKhoaiNavigation)
                    .WithMany(p => p.Thedocgia)
                    .HasForeignKey(d => d.MaTaiKhoai)
                    .HasConstraintName("FKTHEDOCGIA221583");

                entity.HasOne(d => d.MaTaiKhoaiDocGiaNavigation)
                    .WithMany(p => p.Thedocgia)
                    .HasForeignKey(d => d.MaTaiKhoaiDocGia)
                    .HasConstraintName("FKTHEDOCGIA53631");
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTheLoai)
                    .HasName("PK__THELOAI__D73FF34A100DA092");

                entity.ToTable("THELOAI");

                entity.Property(e => e.MaTheLoai)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MoTaTheLoai).HasMaxLength(255);

                entity.Property(e => e.TenTheLoai)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Thuthu>(entity =>
            {
                entity.HasKey(e => e.MaThuThu)
                    .HasName("PK__THUTHU__3A1552A48EF9E70E");

                entity.ToTable("THUTHU");

                entity.Property(e => e.MaThuThu)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CMND");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NamSinh).HasColumnType("date");

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenThuThu)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
