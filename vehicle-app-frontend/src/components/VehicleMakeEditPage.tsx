import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import {
  getVehicleMakeById,
  updateVehicleMake,
} from "../services/vehicleMakeService";
import { TextField, Button, Typography, styled } from "@mui/material";

const Root = styled("div")(() => ({
  display: "flex",
  flexDirection: "column",
  gap: "1rem",
  alignItems: "center",
}));

export function VehicleMakeEditPage() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [form, setForm] = useState({ name: "", abrv: "" });

  useEffect(() => {
    const load = async () => {
      if (id) {
        const data = await getVehicleMakeById(parseInt(id));
        if (data) {
          setForm({ name: data.name, abrv: data.abrv });
        }
      }
    };
    load();
  }, [id]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (id) {
      await updateVehicleMake({ id: parseInt(id), ...form });
      navigate("/brands-list");
    }
  };

  return (
    <Root>
      <Typography
        sx={{
          fontSize: "1.75rem",
          color: "#fff",
          letterSpacing: "5%",
          lineHeight: "2.25rem",
        }}
      >
        Edit Vehicle Brand
      </Typography>

      <TextField
        name="name"
        value={form.name}
        onChange={handleChange}
        sx={{
          borderRadius: "0.25rem",
          width: "100%",
          backgroundColor: "#092E49",
          input: {
            color: "#fff",
            padding: "0.5rem 0.5rem 0.5rem 1rem",
            fontSize: "0.875rem",
            lineHeight: "1.125rem",
          },
          "& .MuiOutlinedInput-notchedOutline": { border: "none" },
          "&:focus-within .MuiOutlinedInput-notchedOutline": {
            border: "2px solid #5798C7",
          },
        }}
      />
      <TextField
        name="abrv"
        value={form.abrv}
        onChange={handleChange}
        sx={{
          borderRadius: "0.25rem",
          width: "100%",
          backgroundColor: "#092E49",
          input: {
            color: "#fff",
            padding: "0.5rem 0.5rem 0.5rem 1rem",
            fontSize: "0.875rem",
            lineHeight: "1.125rem",
          },
          "& .MuiOutlinedInput-notchedOutline": { border: "none" },
          "&:focus-within .MuiOutlinedInput-notchedOutline": {
            border: "2px solid #5798C7",
          },
        }}
      />
      <Button
        sx={{
          width: "100%",
          backgroundColor: "#275B80",
          color: "#fff",
          fontSize: "0.75rem",
          fontWeight: "500",
          letterSpacing: "5%",
          lineHeight: "1rem",
          textTransform: "capitalize",
          padding: "0.5rem 0.75rem",
          borderRadius: "0.5rem",
          "&:hover": { backgroundColor: "#5798C7" },
          "&:active": { backgroundColor: "#7DAFD3" },
        }}
        onClick={handleSubmit}
      >
        Save
      </Button>
    </Root>
  );
}
